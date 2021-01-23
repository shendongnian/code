        /// <summary>
        /// returns a new List<T> without the List<T> which won't have the given parameter 
        ///
        /// Example Usage of the extension method :
        ///
        /// List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };
        /// 
        /// List<int> i = nums.Without(3);
        /// 
        /// </summary>
        /// <typeparam name="TList"> Type of the Caller Generic List </typeparam>
        /// <typeparam name="T"> Type of the Parameter </typeparam>
        /// <param name="list"> Name of the caller list </param>
        /// <param name="item"> Generic item name which exclude from list </param>
        /// <returns>List<T> Returns a generic list </returns>
        public static TList Without<TList, T>(this TList list, T item) where TList : IList<T>, new()
            {
                TList l = new TList();
                foreach (T i in list.Where(n => !n.Equals(item)))
                {
                    l.Add(i);
                }
                return l;
            }
