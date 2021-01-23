    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyList = Dummy2.CompleXList;
    
    namespace Dummy2
    {
        public class Person 
        {
        }
    
        public class CompleXList : List<Person> 
        { 
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                MyList l1 = new MyList();
            }
        }
    }
