    public static class GraphicsLibrary
    {
        public Image RotateImage(Image image, Double angleInDegrees)
        {
           Sqm.TimerStart("GraphicaLibrary.RotateImage");
           ...
           Sqm.TimerStop("GraphicaLibrary.RotateImage");
        }
    }
    public static class DataHelper
    {
        public IDataReader ExecuteQuery(IDbConnection conn, String sql)
        {
           Sqm.TimerStart("DataHelper_ExecuteQuery");
           ...
           Sqm.TimerStop("DataHelper_ExecuteQuery");
        }
    }
    public static class ThemeLib
    {
       public void DrawButton(Graphics g, Rectangle r, String text)
       {
          Sqm.AddToAverage("ThemeLib/DrawButton/TextLength", text.Length);
       }
    }
    private void GetUser(HttpSessionState session)
    {
       LoginUser user = (LoginUser)session["currentUser"];
       
       if (user != null)
          Sqm.Increment("GetUser_UserAlreadyFoundInSession", 1);
       ...
    }
