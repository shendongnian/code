    namespace COMTest
    {
        class Program
        {
            private static ICOMApplication app;
            static void Main( string[] args )
            {
                try
                {
                    //Get the static instance already running
                    app = MyApplication.GetApiInstance();
                    //This line doesn't work. Gives an error about casting __comobject
                    //I also can't cast app to MyApplication (gives the same error
                    //app.MyApplicationClose += OnAppClose;
    
                    Console.WriteLine("Val = " + app.GetVal().ToString());
                    Console.WriteLine("Val = " + app.GetVal().ToString());
                }
                catch (COMException ex)
                {
                    Marshal.ThrowExceptionForHR( ex.ErrorCode );
                }
            }
            static voic OnClose(string s)
            {
                //COM application closed
            }
        }
    }
