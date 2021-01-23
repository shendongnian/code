    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString MyFunctionName(int id) {
        // Put your code here (maybe find the object you want to serialize using the id passed?)
        using (var cn = new SqlConnection("context connection=true") ) {
            //get your data into an object
            var myObject = new {Name = "My Name"};
            return new SqlString(Newtonsoft.Json.JsonConvert.SerializeObject(myObject));
        }
    }
