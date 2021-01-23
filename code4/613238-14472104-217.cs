		using System;
		public static class TypeExtensions {
			static int CountOverlapped<T>(T[] ax, T[] ay) {
				return IntersectPreserveOrder(ay, ax).Length;
			}
			static int CountOccurrence(Type[] ax, Type ty) {
				var a = Array.FindAll(ax, x => Array.Exists(x.GetInterfaces(), tx => tx.Equals(ty)));
				return a.Length;
			}
			static Comparison<Type> GetCoverageComparison(Type[] az) {
				return (tx, ty) => {
					int overlapped, occurrence;
					var ay = ty.GetInterfaces();
					var ax = tx.GetInterfaces();
					if(0!=(overlapped=CountOverlapped(az, ax).CompareTo(CountOverlapped(az, ay)))) {
						return overlapped;
					}
					if(0!=(occurrence=CountOccurrence(az, tx).CompareTo(CountOccurrence(az, ty)))) {
						return occurrence;
					}
					return 0;
				};
			}
			static T[] IntersectPreserveOrder<T>(T[] ax, T[] ay) {
				return Array.FindAll(ax, x => Array.FindIndex(ay, y => y.Equals(x))>=0);
			}
			/*
			static T[] SubtractPreserveOrder<T>(T[] ax, T[] ay) {
				return Array.FindAll(ax, x => Array.FindIndex(ay, y => y.Equals(x))<0);
			}
			static Type[] GetTypesArray(Type typeNode) {
				if(null==typeNode) {
					return Type.EmptyTypes;
				}
				var baseArray = GetTypesArray(typeNode.BaseType);
				var interfaces = SubtractPreserveOrder(typeNode.GetInterfaces(), baseArray);
				var index = interfaces.Length+baseArray.Length;
				var typeArray = new Type[1+index];
				typeArray[index]=typeNode;
				Array.Sort(interfaces, GetCoverageComparison(interfaces));
				Array.Copy(interfaces, 0, typeArray, index-interfaces.Length, interfaces.Length);
				Array.Copy(baseArray, typeArray, baseArray.Length);
				return typeArray;
			}
			*/
			public static Type[] GetInterfaces(this Type x, bool includeThis) {
				var a = x.GetInterfaces();
				if(includeThis&&x.IsInterface) {
					Array.Resize(ref a, 1+a.Length);
					a[a.Length-1]=x;
				}
				return a;
			}
			public static Type FindInterfaceWith(this Type type1, Type type2) {
				var ay = type2.GetInterfaces(true);
				var ax = type1.GetInterfaces(true);
				var types = IntersectPreserveOrder(ax, ay);
				if(types.Length<1) {
					return null;
				}
				Array.Sort(types, GetCoverageComparison(types));
				var type3 = types[types.Length-1];
				if(types.Length<2) {
					return type3;
				}
				var type4 = types[types.Length-2];
				return Array.Exists(type3.GetInterfaces(), x => x.Equals(type4)) ? type3 : null;
			}
			public static Type FindBaseClassWith(this Type type1, Type type2) {
				if(null==type1) {
					return type2;
				}
				if(null==type2) {
					return type1;
				}
				for(var type4 = type2; null!=type4; type4=type4.BaseType) {
					for(var type3 = type1; null!=type3; type3=type3.BaseType) {
						if(type4==type3) {
							return type4;
						}
					}
				}
				return null;
			}
			public static Type FindAssignableWith(this Type type1, Type type2) {
				var baseClass = type2.FindBaseClassWith(type1);
				if(null==baseClass||typeof(object)==baseClass) {
					var @interface = type2.FindInterfaceWith(type1);
					if(null!=@interface) {
						return @interface;
					}
				}
				return baseClass;
			}
		}
