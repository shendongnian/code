		public partial class MyObject {
			public String Name;
		}
		public partial class MyGeneric<U> where U: MyObject {
			private List<T> GetEntities<T>(T entity) where T: U {
				throw new NotImplementedException(); // not implemented yet
			}
			public virtual List<T> Find<T>(Predicate<T> match) where T: U {
				foreach(var myObj in m_List)
					if(match(myObj as T)) {
						// ...
						var name=myObj.Name;
						// ...
						return this.GetEntities(myObj as T);
					}
				return new List<T>();
			}
			List<U> m_List;
		}
