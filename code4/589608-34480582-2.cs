     public  class date_for_my_page
        {
           public date_for_my_page()
           {
               Item item = new Item();
               item.color = "black1";
               item.name = "A";
               Collection.Add(item);
               item = new Item();
               item.color = "black2";
               item.name = "A";
               Collection.Add(item);
               item = new Item();
               item.color = "black3";
               item.name = "A";
               Collection.Add(item);
               item = new Item();
               item.color = "black4";
               item.name = "A";
               Collection.Add(item);
               item = new Item();
               item.color = "black5";
               item.name = "A";
               Collection.Add(item);
               item = new Item();
               item.color = "blue1";
               item.name = "B";
               Collection.Add(item);
               item = new Item();
               item.color = "blue2";
               item.name = "B";
               Collection.Add(item);
               item = new Item();
               item.color = "blue3";
               item.name = "B";
               Collection.Add(item);
               item = new Item();
               item.color = "Red1";
               item.name = "C";
               Collection.Add(item);
               item = new Item();
               item.color = "Red2";
               item.name = "C";
               Collection.Add(item);
           }
            private ItemCollection _Collection = new ItemCollection();
    
            public ItemCollection Collection
            {
                get
                {
                    return this._Collection;
                }
            }
    
            internal List<GroupInfoList<object>> GetGroupsByCategory()
            {
                List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();
    
                var query = from item in Collection
                            orderby ((Item)item).name
                            group item by ((Item)item).name into g
                            select new { GroupName = g.Key, Items = g };
                foreach (var g in query)
                {
                    GroupInfoList<object> info = new GroupInfoList<object>();
                    info.Key = g.GroupName;
                    foreach (var item in g.Items)
                    {
                        info.Add(item);
                    }
                    groups.Add(info);
                }
    
                return groups;
    
            }
    
        }
       public class ItemCollection : IEnumerable<Object>
       {
           private System.Collections.ObjectModel.ObservableCollection<Item> itemCollection = new System.Collections.ObjectModel.ObservableCollection<Item>();
    
           public IEnumerator<Object> GetEnumerator()
           {
               return itemCollection.GetEnumerator();
           }
    
           System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
           {
               return GetEnumerator();
           }
    
           public void Add(Item item)
           {
               itemCollection.Add(item);
           }
       }
       public class GroupInfoList<T> : List<object>
       {
    
           public object Key { get; set; }
    
    
           public new IEnumerator<object> GetEnumerator()
           {
               return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
           }
       }
