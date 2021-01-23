	public class DictionaryFactoryExtension : MarkupExtension, IDictionary
	{
		public Type KeyType { get; set; }
		public Type ValueType { get; set; }
		private IDictionary _dictionary;
		private IDictionary Dictionary
		{
			get
			{
				if (_dictionary == null)
				{
					var type = typeof(Dictionary<,>);
					var dictType = type.MakeGenericType(KeyType, ValueType);
					_dictionary = (IDictionary)Activator.CreateInstance(dictType);
				}
				return _dictionary;
			}
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Dictionary;
		}
		public void Add(object key, object value)
		{
			var converter = TypeDescriptor.GetConverter(KeyType);
			Dictionary.Add(converter.ConvertFrom(key), value);
		}
		#region Other Interface Members
		public void Clear()
		{
			throw new NotSupportedException();
		}
		public bool Contains(object key)
		{
			throw new NotSupportedException();
		}
 		// <Many more properties that do not matter one bit...>
		#endregion
	}
