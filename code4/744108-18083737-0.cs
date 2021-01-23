    public static class SettingsStorageManager
    {
        /// <summary>
        /// Save an object to isolated storage.
        /// </summary>
        /// <param name="key">
        /// The key to store the object with.
        /// </param>
		/// <param name="value">
        /// object to store.
        /// </param>
        public static void Save<T>(string key, T value)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
            {
                IsolatedStorageSettings.ApplicationSettings[key] = value;
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings.Add(key, value);
            }
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
		/// <summary>
        /// Gets an object from the isolated storage based on a key. when object not found, returns a default value of T. 
        /// </summary>
		 /// <param name="key">
        /// The key used to store the object.
        /// </param>
        public static T TryGet<T>(string key)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains(key))
                return default(T);
            return (T) IsolatedStorageSettings.ApplicationSettings[key];
        }
    }
     public static class SettingsStorageFactory
    {
		 /// <summary>
        /// Get's a list of locations from storage.
        /// </summary>
        public static IEnumerable<places> StoragePlaces
        {
            get
            {
                 return SettingsStorageManager.TryGet<IEnumerable<places>>("places").ToSafeList();
            }
        }
	}
    public static class IsolatedStorageExtensions
    {
        public static IEnumerable<T> ToSafeList<T>(this IEnumerable<T> list)
        {
            if (list == null) return Enumerable.Empty<T>();
            return list;
        }
    }
    public static class IsolatedStorageExtensions
    {
        public static IEnumerable<T> ToSafeList<T>(this IEnumerable<T> list)
        {
            if (list == null) return Enumerable.Empty<T>();
            return list;
        }
    }
    public class MyCallingClass
    {
	 var places = SettingsStorageFactory.StoragePlaces;
	 places.Add(new places(this.position_actuelle, this.name.Text)).ToList();
    SettingsStorageManager.Save("places", places);
    }
