    public abstract class DALBaseCache<T>
        {
            public List<T> ItemList
            {
                get
                {
                    List<T> itemList = DALCache.GetItem<List<T>>(typeof(T).Name + "Cache");
    
                    if (itemList != null)
                        return itemList;
                    else
                    {
                        itemList = GetItemList();
                        DALCache.SetItem(typeof(T).Name + "Cache", itemList);
                        return itemList;
                    }
                }
            }
    
            /// <summary>
            /// Get a list of all the Items
            /// </summary>
            /// <returns></returns>
            protected abstract List<T> GetItemList();
    
            /// <summary>
            /// Get the Item based on the ID
            /// </summary>
            /// <param name="name">ID of the Item to retrieve</param>
            /// <returns>The Item with the given ID</returns>
            public T GetItem(int id)
            {
                return (from item in ItemList
                        where (int)item.GetType().GetProperty("ID").GetValue(item, null) == id
                        select item).SingleOrDefault();
            }
    
            /// <summary>
            /// Get the Item based on the Name
            /// </summary>
            /// <param name="name">Name of the Item to retrieve</param>
            /// <returns>The Item with the given Name</returns>
            public T GetItem(string name)
            {
                return (from item in ItemList
                        where (string)item.GetType().GetProperty("Name").GetValue(item, null) == name
                        select item).SingleOrDefault();
            }
        }
