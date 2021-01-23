    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace JsonTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                string message = "Hai \"!Hello\" ";
    
                var project = new Dictionary<string, object>();
                project.Add("key", "TP");
    
                var issuetype = new Dictionary<string, object>();
                issuetype.Add("name", "Bug");
    
                var fields = new Dictionary<string, object>();
                fields.Add("project", project);
                fields.Add("summary", message);
                fields.Add("issuetype", issuetype);
    
                var dict = new Dictionary<string, object>();
                dict.Add("fields", fields);
    
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize((object)dict);
                Console.WriteLine(json);
            }
        }
    }
