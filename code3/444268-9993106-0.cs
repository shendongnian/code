    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> myQuery = null;
            List<Person> peopleList = new List<Person>();
            
            Person p1 = new Person();
            p1.Name = "x"; p1.Age = 15;
            peopleList.Add(p1);
            Person p2 = new Person();
            p2.Name = "y"; p2.Age = 50;
            peopleList.Add(p2);
            string[] myArray = { "15", "56", "17-75", "78", "100-150", "130" };
            foreach (string strAge in myArray)
            {
                string strLocalAge = strAge;
                if (!strLocalAge.Contains("-"))
                {
                    if (myQuery == null)
                    {
                        myQuery = peopleList.Where(p => p.Age == Convert.ToInt32(strLocalAge));
                    }
                    else
                    {
                        myQuery = myQuery.Union(peopleList.Where(p => p.Age == Convert.ToInt32(strLocalAge)));
                    }
                }
                else
                {
                    string[] agePart = strLocalAge.Split(new char[] { '-' });
                    if (agePart.Length == 2)
                    {
                        if (myQuery == null)
                        {
                            myQuery = peopleList.Where(p => p.Age >= Convert.ToInt32(agePart[0]) && p.Age <= Convert.ToInt32(agePart[1]));
                        }
                        else
                        {
                            myQuery = myQuery.Union(peopleList.Where(p => p.Age >= Convert.ToInt32(agePart[0]) && p.Age <= Convert.ToInt32(agePart[1])));
                        }
                    }
                }
            }
            var myresult = myQuery.ToList();
            foreach (Person p in myresult)
            {
                Console.WriteLine("Name: " + p.Name + " Age: " + p.Age.ToString());
            }
           
            Console.ReadLine();
        }
    }
}
