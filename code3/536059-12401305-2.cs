    public void ProcessRequest(HttpContext context)
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                
                string jsonString = String.Empty;
    
                HttpContext.Current.Request.InputStream.Position = 0;
                using (StreamReader inputStream = new StreamReader(HttpContext.Current.Request.InputStream))
                {
                    jsonString = inputStream.ReadToEnd();
                }
                
    
                List<Employee> emplList = new List<Employee>();
                emplList = jsonSerializer.Deserialize<List<Employee>>(jsonString);
    
                string resp = "";
                foreach (Employee emp in emplList)
                {
                    resp += emp.name + " \\ ";
                }
                
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
    
                HttpContext.Current.Response.Write(jsonSerializer.Serialize(resp));
            }
    
            public class Employee
            {
                public string id { get; set; }
                public string name { get; set; }
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
