    public void ProcessRequest(HttpContext context)
    {
        var jsonSerializer = new JavaScriptSerializer();
        var jsonString = String.Empty;
        context.Request.InputStream.Position = 0;
        using (var inputStream = new StreamReader(context.Request.InputStream))
        {
            jsonString = inputStream.ReadToEnd();
        }
        var emplList = jsonSerializer.Deserialize<List<Employee>>(jsonString);
        var resp = String.Empty;
        foreach (var emp in emplList)
        {
            resp += emp.name + " \\ ";
        }
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.Write(jsonSerializer.Serialize(resp));
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
