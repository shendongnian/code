    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<object> objectList = new List<object>();
                var listItem = new List<Person> { new Person { Id = 1, Name = "Person 1" }, new Person { Id = 2, Name = "Person 2" }, new Person { Id = 3, Name = "Person 3" } , new Person { Id = 4, Name = "Person 4" } };
                var start = DateTime.Now;
                var parallelList = listItem;
                //using foreach
                foreach (var item in listItem)
                {
                    object obj = getData(item);
                    objectList.Add(obj);
                }
                var end = DateTime.Now.Subtract(start).TotalSeconds;
                Console.Write("\nUsing foreach...Finish all in " + end + " second \n");
    
                start = DateTime.Now;
                //using Parallel
                Parallel.ForEach(parallelList, item =>
                {
                    object obj = getData(item);
                    objectList.Add(obj);
                });
                end = DateTime.Now.Subtract(start).TotalSeconds;
                Console.Write("Using Parallel...Finish all in "+ end +" second");
                Console.ReadLine();
            }
    
            private static object getData(Person item)
            {
                Thread.Sleep(1000);
                return "Test Object " + item.Id;
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
