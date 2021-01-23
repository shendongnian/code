    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                int IDKey = 1;
                List<SomeClass> UserData = new List<SomeClass>()
                {
                    new SomeClass(),
                    new SomeClass(1),
                    new SomeClass(2)
                };
                //This operation actually works by evaluating the condition provided and adding the
                //object s if the bool returned is true, but we can do other things too
                UserData.Where(s => s.ID == IDKey).ToList();
                //We can actually write an entire method inside the Where clause, like so:
                List<SomeClass> filteredList = UserData.Where((s) => //Create a parameter for the func<SomeClass,bool> by using (varName)
                    {
                        bool theBooleanThatActuallyGetsReturnedInTheAboveVersion =
                            (s.ID == IDKey);
                        if (theBooleanThatActuallyGetsReturnedInTheAboveVersion) s.name = "Changed";
                        return theBooleanThatActuallyGetsReturnedInTheAboveVersion;
                    }
                ).ToList();
    
                foreach (SomeClass item in filteredList)
                {
                    Console.WriteLine(item.name);
                }
            }
        }
        class SomeClass
        {
            public int ID { get; set; }
            public string name { get; set; }
            public SomeClass(int id = 0, string name = "defaultName")
            {
                this.ID = id;
                this.name = name;
            }
        }
    }
