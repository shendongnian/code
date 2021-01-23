		using System;
		public static class TypeVarianceExtensions {
			static readonly Type[] EmptyTypes = Type.EmptyTypes;
			static T[] SubtractPreserveOrder<T>(T[] ax, T[] ay) {
				return Array.FindAll(ax, x => ~0==Array.FindIndex(ay, y => y.Equals(x)));
			}
			static T[] IntersectPreserveOrder<T>(T[] ax, T[] ay) {
				return Array.FindAll(ax, x => ~0!=Array.FindIndex(ay, y => y.Equals(x)));
			}
			static int CountOverlapped<T>(T[] ax, T[] ay) {
				return IntersectPreserveOrder(ay, ax).Length;
			}
			static int CountOccurrence(Type[] ax, Type ty) {
				Predicate<Type> m = x => ~0!=Array.FindIndex(x.GetInterfaces(), tx => tx.Equals(ty));
				return Array.FindAll(ax, m).Length;
			}
			static Comparison<Type> GetCoverageComparison(Type[] az) {
				return (tx, ty) => {
					Type[] ay = ty.GetInterfaces(), ax = tx.GetInterfaces();
					int overlapped, occurrence;
					if(0!=(overlapped=CountOverlapped(az, ax).CompareTo(CountOverlapped(az, ay)))) {
						return overlapped;
					}
					if(0!=(occurrence=CountOccurrence(az, tx).CompareTo(CountOccurrence(az, ty)))) {
						return occurrence;
					}
					return 0;
				};
			}
			static Type[] GetTypesArray(Type typeNode) {
				if(null==typeNode) {
					return EmptyTypes;
				}
				var interfaces = typeNode.GetInterfaces();
				var baseArray = GetTypesArray(typeNode.BaseType);
				interfaces=null==typeNode ? EmptyTypes : SubtractPreserveOrder(interfaces, baseArray);
				var index = interfaces.Length+baseArray.Length;
				var typeArray = new Type[1+index];
				typeArray[index]=typeNode;
				Array.Sort(interfaces, GetCoverageComparison(interfaces));
				Array.Copy(interfaces, 0, typeArray, index-interfaces.Length, interfaces.Length);
				Array.Copy(baseArray, typeArray, baseArray.Length);
				return typeArray;
			}
			public static Type FindInterfaceWith(this Type type1, Type type2) {
				var types = IntersectPreserveOrder(GetTypesArray(type2), GetTypesArray(type1));
				if(types.Length>1) {
					var type3 = types[types.Length-1];
					var type4 = types[types.Length-2];
					if(!type4.IsInterface||!type3.IsInterface) {
						return type3.IsInterface ? type3 : type4;
					}
					else {
						var @interface = FindInterfaceWith(type3, type4);
						return @interface==type4 ? type3 : null;
					}
				}
				else if(types.Length>0) {
					var type = types[0];
					return type.IsInterface ? type : null;
				}
				else {
					return null;
				}
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
			public static Type FindEqualTypeWith(this Type type1, Type type2) {
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
