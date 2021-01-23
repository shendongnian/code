    namespace WebFormsApplication1
    {
        public class Global : HttpApplication
        {
            void Session_Start(object sender, EventArgs e) 
            {
                Global.StartSession();
            }
        }
        
        public static class Global 
        {
            public static void StartSession() {
        
                Session["Test"] = 1;
            }
        }
    }
