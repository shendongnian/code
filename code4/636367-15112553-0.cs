       public class Demo
       {
          public string Name;
          public string Type;
          public string Value;
          public string ChildContentType;
          public string ChildMetadata;
       }
        public void Deserialize()
        {
            string jsonObjString = "[{\"Name\": \"Description\",\"Type\": \"Text\",\"Value\": \"XXX\",\"ChildContentType\": \"Value\",\"C??hildMetadata\": \"YYY\"}]";
             var ser = new JavaScriptSerializer();
             var arreyDemoObj = ser.Deserialize<Demo[]>(jsonObjString);
             
             foreach (Demo objDemo in arreyDemoObj)
             {
                 //Do what you want with objDemo
             }
          }
      
