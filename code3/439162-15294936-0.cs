    class ContactListViewModel
        {
    
            public ContactListViewModel()
            {
                ContactSource = new CollectionViewSource();
                Contacts = new ObservableCollection<Contact>();
    
                Contacts.Add(new Contact("Gates","Bill"));
                Contacts.Add(new Contact("Bush","Georges"));
                Contacts.Add(new Contact("Obama","Barack"));
                Contacts.Add(new Contact("Holland","François"));
                Contacts.Add(new Contact("Affleck","Ben"));
                Contacts.Add(new Contact("Allen","Woody"));
                Contacts.Add(new Contact("Hendrix","Jimi"));
                Contacts.Add(new Contact("Harrison", "Georges"));
    
                Contacts = new ObservableCollection<Contact>(Contacts.OrderBy(c => c.Name));
                ContactSource.Source = GetGroupsByLetter();
                ContactSource.IsSourceGrouped = true;
    
            }
    
            #region Contacts
            public ObservableCollection<Contact> Contacts
            {
                get;
                protected set;
            }
    
            public CollectionViewSource ContactSource
            {
                get;
                protected set;
            }
            #endregion
    
    
            internal List<GroupInfoList<object>> GetGroupsByLetter()
            {
                List<GroupInfoList<object>> groups = new List<GroupInfoList<object>>();
    
                var query = from item in Contacts
                            orderby ((Contact)item).Name
                            group item by ((Contact)item).Name[0] into g
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
    
            public class GroupInfoList<T> : List<object>
            {
    
                public object Key { get; set; }
    
    
                public new IEnumerator<object> GetEnumerator()
                {
                    return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
                }
            }
    }
