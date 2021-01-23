		public partial class TreeOfObject: ITree<object> {
			public T Union<T>(T other) where T: ITree<object> {
				return default(T); // sample only; shuold be implemented yourself
			}
		}
		public partial class TreeOfInt: ITree<int> {
			public T Union<T>(T other) where T: ITree<int> {
				return default(T); // sample only; shuold be implemented yourself
			}
		}
