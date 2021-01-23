    using System;
    namespace StackOverflowDemo.Applications.TestFrameworkDemo.Data
    {
        public interface IDataSource
        {
            string GetTitle(int id);
        }
        public class Database: IDataSource
        {
            public string GetTitle(int id)
            {
                string result;
                //logic to connect to a database and retrieve a value would go here
                switch (id)
                {
                    case 1: result = "DB First Title"; break;
                    case 2: result = "DB Second Title"; break;
                    default: throw new KeyNotFoundException(string.Format("ID '{0}' not found",id));
                }
                return result;
            }
        
        }
    }
    using System;
    using StackOverflowDemo.Applications.TestFrameworkDemo.Data;
    namespace StackOverflowDemo.Applications.TestFrameworkDemo.DataTest
    {
        public class DatabaseMock : IDataSource
        {
            public string GetTitle(int id)
            {
                string result;
                switch (id)
                {
                    case 1: result = "DBMock First Title"; break;
                    case 2: result = "DBMock Second Title"; break;
                    default: throw new KeyNotFoundException(string.Format("ID '{0}' not found", id));
                }
                return result;
            }
        }
    }
    using System;
    using StackOverflowDemo.Applications.TestFrameworkDemo.Data;
    namespace StackOverflowDemo.Applications.TestFrameworkDemo.Logic
    {
        public class SomeBusinessObject
        {
            private IDataSource myData;
            public SomeBusinessObject(IDataSource myData)
            {
                this.myData = myData;
            }
            public void OutputTitle(int id)
            {
                Console.WriteLine(myData.GetTitle(id));
            }
        }
    }
    using System;
    using StackOverflowDemo.Applications.TestFrameworkDemo.Data;
    //using StackOverflowDemo.Applications.TestFrameworkDemo.DataTest; //we don't need the using statement if we use the whole path below, which I think relates to your question
    using StackOverflowDemo.Applications.TestFrameworkDemo.Logic;
    namespace StackOverflowDemo.Applications.TestFrameworkDemo
    {
        class Program
        {
            public static void Main(string[] args)
            {
                IDataSource myData;
    #if(DEBUG)
                myData = new StackOverflowDemo.Applications.TestFrameworkDemo.DataTest.DatabaseMock();
    #else
                myData = new Database();
    #endif
                SomeBusinessObject sbo = new SomeBusinessObject(myData);
                sbo.OutputTitle(1);
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
    }
