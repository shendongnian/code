    class Program
    {
        static void Main(string[] args)
        {
            var list = new Contacts();
            var a = new Contact() { Name = "a" };
            var b = new Contact() { Name = "b" };
            var c = new Contact() { Name = "c" };
            var d = new Contact() { Name = "d" };
            list.ContactList = new List<Contact>();
            list.ContactList.Add(a);
            list.ContactList.Add(b);
            list.ContactList.Add(c);
            list.ContactList.Add(d);
            foreach (var i in list)
            {
                Console.WriteLine(i.Name);
            }
        }
    }
    class Contacts : IEnumerable<Contact>
    {
        public List<Contact> ContactList { get; set; }
        public IEnumerator<Contact> GetEnumerator()
        {
            return ContactList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ContactList.GetEnumerator();
        }
    }
    class Contact
    {
        public string Name { get; set; }
    }
