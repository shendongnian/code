    using System.Web.Services;
    ...
    [WebMethod]
    public static String SetName(string name)
    {
        return "This was called from " + name;
    }
