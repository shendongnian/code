	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;
	using System.Reflection.Emit;
	using System.Runtime.CompilerServices;
	using System.Threading;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				dynamic DefaultConfig = new
				{
					BlacklistedDomains = new string[] { "domain1.com" },
					ExternalConfigFile = "blacklist.txt",
					UseSockets = new[] { 
						new { IP = "127.0.0.1", Port = "80" }, 
						new { IP = "127.0.0.2", Port = "8080" } 
					}
				};
				dynamic UserSpecifiedConfig = new
				{
					BlacklistedDomains = new string[] { "example1.com" },
					ExternalConfigFile = "C:\\my_blacklist.txt"
				};
				var result = Merge(UserSpecifiedConfig, DefaultConfig);
				// result should now be equal to: 
				var result_equal = new
				{
					BlacklistedDomains = new string[] { "domain1.com", "example1.com" },
					ExternalConfigFile = "C:\\my_blacklist.txt",
					UseSockets = new[] {         
						new { IP = "127.0.0.1", Port = "80"},         
						new { IP = "127.0.0.2", Port = "8080" }     
					}
				};
				Debug.Assert(result.Equals(result_equal));
			}
			/// <summary>
			/// Merge the properties of two dynamic objects, taking the LHS as primary
			/// </summary>
			/// <param name="lhs"></param>
			/// <param name="rhs"></param>
			/// <returns></returns>
			static dynamic Merge(dynamic lhs, dynamic rhs)
			{
				// get the anonymous type definitions
				Type lhsType = ((Type)((dynamic)lhs).GetType());
				Type rhsType = ((Type)((dynamic)rhs).GetType());
				//PropertyBuilder propBuilder = new System.Reflection.Emit.PropertyBuilder();
				//MethodBuilder methodBuilder = new System.Reflection.Emit.MethodBuilder();
			
				object result = new { };
				var resProps = new Dictionary<string, PropertyInfo>();
				var resVals = new Dictionary<string, object>();
				var lProps = lhsType.GetProperties().ToDictionary<PropertyInfo, string>(prop => prop.Name);
				var rProps = rhsType.GetProperties().ToDictionary<PropertyInfo, string>(prop => prop.Name); 
				foreach (string leftPropKey in lProps.Keys)
				{
					var lPropInfo = lProps[leftPropKey];
					resProps.Add(leftPropKey, lPropInfo);
					var lhsVal = Convert.ChangeType(lPropInfo.GetValue(lhs, null), lPropInfo.PropertyType);
					if (rProps.ContainsKey(leftPropKey))
					{
						PropertyInfo rPropInfo;
						rPropInfo = rProps[leftPropKey];
						var rhsVal = Convert.ChangeType(rPropInfo.GetValue(rhs, null), rPropInfo.PropertyType);
						object setVal = null;
						if (lPropInfo.PropertyType.IsAnonymousType())
						{
							setVal = Merge(lhsVal, rhsVal);
						}
						else if (lPropInfo.PropertyType.IsArray)
						{
							var bound = ((Array) lhsVal).Length + ((Array) rhsVal).Length;
							var cons = lPropInfo.PropertyType.GetConstructor(new Type[] { typeof(int) });
							dynamic newArray = cons.Invoke(new object[] { bound });
							//newArray = ((Array)lhsVal).Clone();
							int i=0;
							while (i < ((Array)lhsVal).Length)
							{
								newArray[i] = lhsVal[i];
								i++;
							}
							while (i < bound)
							{
								newArray[i] = rhsVal[i - ((Array)lhsVal).Length];
								i++;
							}
							setVal = newArray;
						}
						else
						{
							setVal = lhsVal == null ? rhsVal : lhsVal;
						}
						resVals.Add(leftPropKey, setVal);
					}
					else 
					{
						resVals.Add(leftPropKey, lhsVal);
					}
				}
				foreach (string rightPropKey in rProps.Keys)
				{
					if (lProps.ContainsKey(rightPropKey) == false)
					{
						PropertyInfo rPropInfo;
						rPropInfo = rProps[rightPropKey];
						var rhsVal = rPropInfo.GetValue(rhs, null);
						resProps.Add(rightPropKey, rPropInfo);
						resVals.Add(rightPropKey, rhsVal);
					}
				}
				Type resType = TypeExtensions.ToType(result.GetType(), resProps);
				result = Activator.CreateInstance(resType);
				foreach (string key in resVals.Keys)
				{
					var resInfo = resType.GetProperty(key);
					resInfo.SetValue(result, resVals[key], null);
				}
				return result;
			}
		}
	}
	public static class TypeExtensions
	{
		public static Type ToType(Type type, Dictionary<string, PropertyInfo> properties)
		{
			AppDomain myDomain = Thread.GetDomain();
			Assembly asm = type.Assembly;
			AssemblyBuilder assemblyBuilder = 
				myDomain.DefineDynamicAssembly(
				asm.GetName(), 
				AssemblyBuilderAccess.Run
			);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(type.Module.Name);
			TypeBuilder typeBuilder = moduleBuilder.DefineType(type.Name,TypeAttributes.Public);
			foreach (string key in properties.Keys)
			{
				string propertyName = key;
				Type propertyType = properties[key].PropertyType;
				FieldBuilder fieldBuilder = typeBuilder.DefineField(
					"_" + propertyName,
					propertyType,
					FieldAttributes.Private
				);
				PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(
					propertyName,
					PropertyAttributes.HasDefault,
					propertyType,
					new Type[] { }
				);
				// First, we'll define the behavior of the "get" acessor for the property as a method.
				MethodBuilder getMethodBuilder = typeBuilder.DefineMethod(
					"Get" + propertyName,
					MethodAttributes.Public,
					propertyType,
					new Type[] { }
				);
				ILGenerator getMethodIL = getMethodBuilder.GetILGenerator();
				getMethodIL.Emit(OpCodes.Ldarg_0);
				getMethodIL.Emit(OpCodes.Ldfld, fieldBuilder);
				getMethodIL.Emit(OpCodes.Ret);
				// Now, we'll define the behavior of the "set" accessor for the property.
				MethodBuilder setMethodBuilder = typeBuilder.DefineMethod(
					"Set" + propertyName,
					MethodAttributes.Public,
					null,
					new Type[] { propertyType }
				);
				ILGenerator custNameSetIL = setMethodBuilder.GetILGenerator();
				custNameSetIL.Emit(OpCodes.Ldarg_0);
				custNameSetIL.Emit(OpCodes.Ldarg_1);
				custNameSetIL.Emit(OpCodes.Stfld, fieldBuilder);
				custNameSetIL.Emit(OpCodes.Ret);
				// Last, we must map the two methods created above to our PropertyBuilder to 
				// their corresponding behaviors, "get" and "set" respectively. 
				propertyBuilder.SetGetMethod(getMethodBuilder);
				propertyBuilder.SetSetMethod(setMethodBuilder);
			}
			//MethodBuilder toStringMethodBuilder = typeBuilder.DefineMethod(
			//    "ToString",
			//    MethodAttributes.Public,
			//    typeof(string),
			//    new Type[] { }
			//);
			return typeBuilder.CreateType();
		}
		public static Boolean IsAnonymousType(this Type type)
		{
			Boolean hasCompilerGeneratedAttribute = type.GetCustomAttributes(
				typeof(CompilerGeneratedAttribute), false).Count() > 0;
			Boolean nameContainsAnonymousType =
				type.FullName.Contains("AnonymousType");
			Boolean isAnonymousType = hasCompilerGeneratedAttribute && nameContainsAnonymousType;
			return isAnonymousType;
		}
	}
