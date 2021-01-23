        static void Main(string[] args)
        {
            // http://stackoverflow.com/questions/16496998/how-to-copy-a-list-to-another-list-with-comparsion-in-c-sharp
            List<Template> listForTemplate = new Template[] {
                new Template(){ID = "1"},
                new Template(){ID = "2"},
                new Template(){ID = "3"},
                new Template(){ID = "4"},
                new Template(){ID = "5"},
                new Template(){ID = "6"},
            }.ToList();
            List<Template1> listForTemplate1 = new Template1[] {
                new Template1(){ID = "1"},
                new Template1(){ID = "3"},
                new Template1(){ID = "5"}
            }.ToList();
            var comp = new ObjectWithIDComparer();
            var matches = listForTemplate.Intersect(listForTemplate1, comp);
            var ummatches = listForTemplate.Except(listForTemplate1, comp);
            Console.WriteLine("Matches:");
            foreach (var item in matches) // note that item is instance of ObjectWithID
            {
                Console.WriteLine("{0}", item.ID);
            }
            Console.WriteLine();
            Console.WriteLine("Ummatches:");
            foreach (var item in ummatches) // note that item is instance of ObjectWithID
            {
                Console.WriteLine("{0}", item.ID);
            }
            Console.WriteLine();
        }
    }
    public class ObjectWithIDComparer : IEqualityComparer<ObjectWithID>
    {
        public bool Equals(ObjectWithID x, ObjectWithID y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(ObjectWithID obj)
        {
            return obj.ID.GetHashCode();
        }
    }
    public interface ObjectWithID {
        string ID { get; set; }
    }
    public class Template : ObjectWithID
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    public class Template1 : ObjectWithID
    {
        public string ID { get; set; }
    }
