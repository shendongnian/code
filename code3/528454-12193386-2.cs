    public class MyControl : Button, IPostBackEventHandler
      {
    
        // Use the constructor to defined default label text.
        public MyControl()
        {
        }
    
        // Implement the RaisePostBackEvent method from the
        // IPostBackEventHandler interface. 
        public void RaisePostBackEvent(string eventArgument)
        {
          //You receive the row number here.
        }
      }
