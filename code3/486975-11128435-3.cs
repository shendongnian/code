    [WebMethod]
    public static void done(string[] ids)
    {
       String[] a = ids;
       // Do whatever processing you want
       // However, you cannot access server controls
       // in a static web method.
    }
