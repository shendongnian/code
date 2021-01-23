    public partial class ViewerPage : PhoneApplicationPage
    {
        private Callback m_callback;
    
        ... // rest of ViewPage class
    
        // used as a callback from the native component to here
        // just delegates calls to the page
        class Callback : ICallback
        {
            public Callback()
            {
            }
    
            // just delegates to the page
            public void BeginProgress(String message)
            {
                BeginProgress(message);
            }
    
            public void CompleteProgress(int result, String message)
            {
                CompleteProgress(result, message);
            }
        }
    }
-.- 
