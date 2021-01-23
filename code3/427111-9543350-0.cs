    public class Foo {
            private MyDbContext _db = new MyDbContext();
    
            public void HelloWorld() {
    
                _db.Contacts.Local.CollectionChanged += ContactsChanged;
    
                Contact contact = ....; //< A contact from database.
    
                ContactField field = ....; ///< A new field 
                .... ///< assign other properties into this `field`
                field.FieldType = FieldType.Phone;
    
                // How to automatically update `SortOrder` 
                // when adding field into `ContactFields`
                contact.ContactFields.Add(field);
    
                _db.SaveChanges();
            }
    
            public void ContactsChanged(object sender, NotifyCollectionChangedEventArgs args) {
                 
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
    
                    // sort
                }    
            }
    }
