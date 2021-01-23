    public class MyClass
	{
		private readonly Dictionary<String, Object> dictionary;
		private readonly Dictionary<String, Func<Object, bool>> validators;
		public MyClass()
		{
			this.dictionary = new Dictionary<String, Object>();
			this.validators = new Dictionary<String, Func<Object, bool>>();
			
			// Put the default values in the dictionary.
			this.dictionary["One"] = 10;
			this.dictionary["Another"] = "ABC";
			
			// The validation functions:
			this.validators["One"] = obj => ((int)obj) >= 0;
			this.validators["Another"] = obj => obj != null;
		}
		public Object this[string name]
		{
			get { return this.dictionary[name]; }
			set
			{
				// This assumes the dictionary contains a default for _all_ names.
				if (!this.dictionary.Contains(name))
					throw new ArgumentException("Name is invalid.");
				
				// Get a validator function. If there is one, it must return true.
				Func<Object, bool> validator;
				if (validators.TryGetValue(name, out validator) &&
					!validator(value))
					throw new ArgumentException("Value is invalid.");
				
				// Now set the value.
				this.dictionary[name] = value;
			}
		}
	}
    
