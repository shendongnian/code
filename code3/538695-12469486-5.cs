    	// this will return a list of the values contained in the properties...
		public List<string> GetListFromProperties<T>(T instance)
		{
			Type t = typeof(T);
			PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			// As a simple list...
			List<string> artists = new List<string>(props.Length);
			for (int i = 0; i < props.Length; i++)
			{
				if(!props[i].Name.Contains("_artist")){ continue; }
				artists.Add(props[i].GetValue(instance, null).ToString());
			}
			return artists;
		}
		// this will return a dictionary which has each artist stored
		// under a key which is the name of the property the artist was in.
		public Dictionary<string,string> GetDictionaryFromProperties<T>(T instance)
		{
			Type t = typeof(T);
			PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			// As a dictionary...
			Dictionary<string,string> artists = new Dictionary<string,string>(props.Length);
			for (int i = 0; i < props.Length; i++)
			{
				if(artists.ContainsKey(props[i].Name) || !props[i].Name.Contains("_artist")){ continue; }
				artists.Add(props[i].Name, props[i].GetValue(instance, null).ToString());
			}
			return artists;
		}
