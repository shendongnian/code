    class SomeHandler {
    
       private static readonly _instance = new SomeHandler ();
    
       static SomeHandler Instance {
          get { return _instance; }
    
       public void SomeEventHandler (object sender, EventArgs e) {
          // handle event
       }
    }
