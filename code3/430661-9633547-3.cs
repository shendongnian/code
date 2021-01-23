    public class Test
    {
        public String Name;
        public Int32 Age;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<String> l_lstNames = new List<String> { "A1", "A3", "A2", "A4", "A0" };
    
            List<Test> l_lstStudents = new List<Test> 
                                        { new Test { Age = 20, Name = "A0" }, 
                                          new Test { Age = 21, Name = "A1" }, 
                                          new Test { Age = 22, Name = "A2" }, 
                                          new Test { Age = 23, Name = "A3" }, 
                                          new Test { Age = 24, Name = "A4" }, 
                                        };
    
            l_lstStudents = l_lstStudents.OrderBy(x => l_lstNames.IndexOf(x.Name)).ToList();
        }
    }
