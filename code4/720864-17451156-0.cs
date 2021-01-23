    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList();
            var contacts = new ContactCollection();
            var partnerships = new PartnershipCollection();
            contacts.Add(new Contact());
            partnerships.Add(new Partnership());
            list.Add(contacts);
            list.Add(partnerships);
            list.ClearCollections();
        }
        class MyList : List<ICollection<IObject>>
        {
            public void ClearCollections()
            {
                this.ForEach((a) => a.Clear());
            }
        }
        interface IObject { }
        class Contact : IObject { }
        class Partnership : IObject { }
        class ContactCollection : ICollection<IObject> { }
        class PartnershipCollection : ICollection<IObject> { }
    }
