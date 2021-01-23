	partial class Foo {
		class NameComparer: IComparer<Name> {
			public int Compare(Name x, Name y) {
				return
					object.ReferenceEquals(x, y)
					||y.LastName==x.LastName&&y.FirstName==x.FirstName?0:~0;
			}
			public static readonly NameComparer Default=new NameComparer();
		}
		public bool Any(Name x) {
			return
				Names.Any(
					y => object.ReferenceEquals(x, y)
					||y.LastName==x.LastName&&y.FirstName==x.FirstName);
		}
		public bool Contains(Name x) {
			return Names.BinarySearch(x, NameComparer.Default)>~0;
		}
	}
