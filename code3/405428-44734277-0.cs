    namespace HashSet
{
    public class Employe
    {
        public Employe() {
        }
        public string Name { get; set; }
        public override string ToString()  {
            return Name;
        }
        public override bool Equals(object obj) {
            return this.Name.Equals(((Employe)obj).Name);
        }
        public override int GetHashCode() {
            return this.Name.GetHashCode();
        }
    }
    class EmployeComparer : IEqualityComparer<Employe>
    {
        public bool Equals(Employe x, Employe y)
        {
            return x.Name.Trim().ToLower().Equals(y.Name.Trim().ToLower());
        }
        public int GetHashCode(Employe obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Employe> hashSet = new HashSet<Employe>(new EmployeComparer());
            hashSet.Add(new Employe() { Name = "Nik" });
            hashSet.Add(new Employe() { Name = "Rob" });
            hashSet.Add(new Employe() { Name = "Joe" });
            Display(hashSet);
            hashSet.Add(new Employe() { Name = "Rob" });
            Display(hashSet);
            HashSet<Employe> hashSetB = new HashSet<Employe>(new EmployeComparer());
            hashSetB.Add(new Employe() { Name = "Max" });
            hashSetB.Add(new Employe() { Name = "Solomon" });
            hashSetB.Add(new Employe() { Name = "Werter" });
            hashSetB.Add(new Employe() { Name = "Rob" });
            Display(hashSetB);
            var union = hashSet.Union<Employe>(hashSetB).ToList();
            Display(union);
            var inter = hashSet.Intersect<Employe>(hashSetB).ToList();
            Display(inter);
            var except = hashSet.Except<Employe>(hashSetB).ToList();
            Display(except);
            Console.ReadKey();
        }
        static void Display(HashSet<Employe> hashSet)
        {
            if (hashSet.Count == 0)
            {
                Console.Write("Collection is Empty");
                return;
            }
            foreach (var item in hashSet)
            {
                Console.Write("{0}, ", item);
            }
            Console.Write("\n");
        }
        static void Display(List<Employe> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Collection is Empty");
                return;
            }
            foreach (var item in list)
            {
                Console.Write("{0}, ", item);
            }
            Console.Write("\n");
        }
    }
