        public class Undergrad
        {
            String fName, lName;
    
            public Undergrad()
            {
            }
    
            public Undergrad(string firstName, string lastName)
            {
                this.fName = firstName;
                this.lName = lastName;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Undergrad> lstGraduates = new List<Undergrad>() { new Undergrad("f1", "l1"), new Undergrad("f2", "l2"), new Undergrad("f3", "l3") };
                int i = 0;
                ILookup<int, Undergrad> lookup = lstGraduates.ToLookup(p => i++);
    
                foreach (IGrouping<int, Undergrad> packageGroup in lookup)
                {
                    Console.WriteLine(packageGroup.Key);
                    Undergrad obj = (Undergrad)packageGroup;                
                }
                Console.Read();
            }
        }
