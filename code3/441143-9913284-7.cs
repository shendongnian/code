    public class _Default : System.Web.Page
    
    {
        public _Default()
        {
             this.Init += (_o, _e) =>
              {
                  SendEmail.Click += SendEmail_Click;
              };
        }
    }
