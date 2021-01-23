          public class ajax : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)  { Stream dataStream = context.Request.InputStream;
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                Dictionary<string, object> data = (Dictionary<string, object>)json_serializer.DeserializeObject(responseFromServer);
                selected_user u = new selected_user();
                u.user_name = data["uname"].ToString();
                u.pass = data["pass"].ToString();
                u.sname = data["lname"].ToString();         
