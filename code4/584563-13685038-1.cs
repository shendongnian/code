	using System;
	using System.Linq;
	using System.Reflection;
	using MINT;
	using MbUnit.Framework;
	using Mono.Reflection;
	namespace TestDll
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				const string DllPath = @"d:\SprinterAutomation\Actions.Tests\bin\x86\Debug\Actions.Tests.dll";
				Assembly assembly = Assembly.LoadFrom(DllPath);
				// enumerating Fixtures
				foreach (Type fixture in assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(TestFixtureAttribute), false).Length > 0)) 
				{
					Console.WriteLine(fixture.Name);
					// enumerating Test Methods
					foreach (var testMethod in fixture.GetMethods().Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0))
					{
						Console.WriteLine("\t" + testMethod.Name);
						// filtering Actions
						var instructions = testMethod.GetInstructions().Where(
							i => i.OpCode.Name.Equals("newobj") && ((ConstructorInfo)i.Operand).DeclaringType.IsSubclassOf(typeof(BaseAction)));
						// enumerating Actions!
						foreach (Instruction action in instructions)
						{
							var constructroInfo = action.Operand as ConstructorInfo;
							Console.WriteLine("\t\t" + constructroInfo.DeclaringType.Name);
						}
					}
				}
			}
		}
	}
