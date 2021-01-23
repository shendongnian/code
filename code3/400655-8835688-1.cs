    	/// <summary>
		/// Get the list with names and descriptions of Enum
		/// </summary>
		/// <typeparam name="T">Enum Type</typeparam>
		/// <param name="usarNome">if true the key is the Enum name</param>
		/// <returns>List with names and descriptions</returns>
		public static IEnumerable<KeyValuePair<string, T>> GetEnumList<T>(bool usarNome)   
		{   
			var x = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T)));   
			return	from field in x   
					select new KeyValuePair<string, T>(GetEnumDescription(field, usarNome), (T)Enum.Parse(typeof(T), field.Name, false));    
		}   
