    [Webmethod]
    public static void display()
    {
         HttpContext.Current.Response.Write( "Hello");
    }
