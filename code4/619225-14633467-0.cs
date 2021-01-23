    using System;
    using System.Web.Script.Serialization;
    namespace JSON_Serialization_Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string json = "{'123353054': 'value here','username': 'value here'}";
                var jss = new JavaScriptSerializer();
                var csobj = jss.Deserialize<dynamic>(json);
                Console.WriteLine(csobj.GetType());
                Console.Read();
            }
        }
    }
