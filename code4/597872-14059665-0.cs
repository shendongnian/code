    public class Program
    {
      
        static void Main(string[] args)
        {
           
          var p = new Person
            {
                FirstName = "Daniel",
                LastName = "Endeg"
            };
            var x = new XmlSerializer(p.GetType());
            x.Serialize(Console.Out, p);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
