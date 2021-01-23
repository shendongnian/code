    public partial class _Default : Page 
    {
      [WebMethod]
      public static string GetDate(string someParameter)
      {
        return DateTime.Now.ToString();
      }
    }
