    public class MyClass
        {
            public void Do_your_thing()
            {
                // for async execution
                Task.Factory.StartNew(Running_code);
    
                // for synchronous execution
                // CAUTION !! If invoked from UI thread this will freeze the GUI until Running_code is returned.
                //Task.Factory.StartNew(Running_code).Wait(); 
            }
    
            private void Running_code()
            {
               Thread.Sleep( 2000 );
               Debug.WriteLine( "Something was done" );
            }
        }
