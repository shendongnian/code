	public abstract class DMO<T> where T: Extender<Dao> {
		public abstract Dictionary<T, PropertyInfo> Properties {
			get;
			set;
		}
		// ...
	}
