    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace App
    {
        public class DataSet
        {
        }
        public class someclass
        {
            public DataSet Where(Func<Person, Boolean> matcher)
            {
                Person anotherone = new Person();
                matcher(anotherone);
                return new DataSet();
            }
        }
        public class Person
        {
            public string LeaderID, UserID;
        }
        class Program
        {
            public static Dictionary<String, someclass> ViewData;
            private static void SomeFunction(Func<Person, DataSet> getDataSet)
            {
                Person thepersonofinterest = new Person();
                DataSet thesetiamusinghere = getDataSet(thepersonofinterest);
            }
            static void Main(string[] args)
            {
                SomeFunction((m) => { return ViewData["AllEmployees"].Where((c) => {return (c.LeaderID == m.UserID); }});
            }
        }
    }
