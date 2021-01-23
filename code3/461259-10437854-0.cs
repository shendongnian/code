    public class Session
    {
        public User User
        {
            get { return Get<User>("User"); }
            set {Set<User>("User", value);}
        }
        /// <summary> Gets. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <returns> . </returns>
        private T Get<T>(string key)
        {
            object o = HttpContext.Current.Session[key];
            if(o is T)
            {
                return (T) o;
            }
            
            return default(T);
        }
        /// <summary> Sets. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="key">  The key. </param>
        /// <param name="item"> The item. </param>
        private void Set<T>(string key, T item)
        {
            HttpContext.Current.Session[key] = item;
        }
    }
