    public partial class admpDBcontext : DbContext
{
    public static string name
    {
        get
        {
            if (System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority).ToString() == "http://fcoutl.vogmtl.com")
            {
               return "name=admpDBcontext";
            }
            else { return "name=admpNyDBcontext"; }
        }
        
    }
    public admpDBcontext()
        : base(name)
    {
    }
