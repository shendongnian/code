    public class AccountsView {
        public string Username;
        public string Email;
        public string Password;
    }
    public void ProcessRequest(HttpContext context)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string value = context.Request["obj"];
        var aView = serializer.Deserialize(value, typeof(AccountsView));
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = Encoding.UTF8;
    }
