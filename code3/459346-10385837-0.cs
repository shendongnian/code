    class Program
    {
        static void Main(string[] args)
        {
            var totalOfAllAges = 0D;
            var people = new ExcelRow();
            foreach (var item in people.GetPerson())
            {
                //calculate stats
                totalOfAllAges += item.Age;
            }
    
            Console.WriteLine("The total of all ages is {0}", totalOfAllAges);
        }
    }
    
    internal class ExcelRow
    {        
        private int rowCount = 150000000;
        private int rowIndex = 0;
    
        public IEnumerable<Person> GetPerson()
        {
            while (rowIndex < rowCount)
            {
                rowIndex++;
                yield return new Person() { Age = rowIndex };
            }
        }
    }
    
    internal class Person
    {
        public int Age { get; set; }
    }
