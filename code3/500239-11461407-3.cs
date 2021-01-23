    using System;
    using System.Web.Services;
    using System.Collections.Generic;
    
    public partial class _Default : System.Web.UI.Page
    {
    
        [WebMethod]
        public static List<SampleClass> retrieveData()
        {
            //Retrieve data from the server and return.
            List<SampleClass> tmp = new List<SampleClass>();
    
            tmp.Add(new SampleClass() { Name = "Test", LastName = "Number 1", Age = 44 });
            tmp.Add(new SampleClass() { Name = "Test", LastName = "Number 2", Age = 23 });
            tmp.Add(new SampleClass() { Name = "Test", LastName = "Number 3", Age = 20 });
            tmp.Add(new SampleClass() { Name = "Test", LastName = "Number 4", Age = 45 });
            tmp.Add(new SampleClass() { Name = "Test", LastName = "Number 5", Age = 21 });
    
            return tmp;
        }
    
        [WebMethod]
        public static bool insertData()
        {
            //Do all of the insert in the server blah blah blah
            //and return true or false if it was inserted.
            return true;
    
        }
    }
    
    public class SampleClass
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
