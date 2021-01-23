<!-- -->
	partial class TypeExtensions {
		static readonly Type[] EmptyArray=new Type[] { };
		static T[] Subtract<T>(this T[] ax, T[] ay) {
			return Array.FindAll(ax, x => false==Array.Exists(ay, y => y.Equals(x)));
		}
		static T[] Intersect<T>(this T[] ax, T[] ay) {
			return Array.FindAll(ax, x => Array.Exists(ay, y => y.Equals(x)));
		}
		static int GetOccurrenceCount(this Type[] ax, Type ty) {
			return Array.FindAll(ax, x => Array.Exists(x.GetInterfaces(), tx => tx.Equals(ty))).Length;
		}
		static int GetOverlappedCount<T>(this T[] ax, T[] ay) {
			return ay.Intersect(ax).Length;
		}
		static Comparison<Type> CoverageComparison(this Type[] az) {
			return
				(tx, ty) => {
					var ay=ty.GetInterfaces();
					var ax=tx.GetInterfaces();
					var overlapped=az.GetOverlappedCount(ax).CompareTo(az.GetOverlappedCount(ay));
					if(0!=overlapped)
						return overlapped;
					else {
						var occurrence=az.GetOccurrenceCount(tx).CompareTo(az.GetOccurrenceCount(ty));
						if(0!=occurrence)
							return occurrence;
						else
							return 0;
					}
				};
		}
	}
