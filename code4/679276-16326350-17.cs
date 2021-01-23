    namespace MyNamespace
    {
        [ComVisible( true ),
        GuidAttribute( "14C09983-FA4B-44e2-9910-6461728F7883" ),
        InterfaceType( ComInterfaceType.InterfaceIsDual )]
        public interface ICOMApplication
        {    
            [DispId(1)]
            int GetVal();
        }
        //Events for my com interface. Must be IDispatch
        [Guid( "E00FA736-8C24-467a-BEA0-F0AC8E528207" ),
        InterfaceType( ComInterfaceType.InterfaceIsIDispatch ),
        ComVisible( true )]
        public interface ICOMEvents
        {
            [DispId( 1 )]
            void ComAppClose( string s );
        }
        
        public delegate void ComEvent( string p );
    
        [ComVisible(true)]
        [Guid( "ECE6FD4C-52FD-4D72-9668-1F3696D9A99E" )]
        [ComSourceInterfaces( typeof( ICOMWnEvents) )]
        [ClassInterface( ClassInterfaceType.None )]
        public class MyApplication : ICOMApplication, IDisposable
        {
            //ICOMEvent
            public event ComEvent ComAppClose; 
         
            protected MyApplication ()
            {
                //check if application is registered.
                //if not registered then register the application
                if (GetApiInstance() == null)
                {
                    Register_COMI();
                }
            }
    
            // UCOMI-Version to register in the ROT
            protected void Register_COMI()
            {
                int errorcode;
                IRunningObjectTable rot;
                IMoniker moniker;
                int register;
    
                errorcode = Ole32.GetRunningObjectTable( 0, out rot );
                Marshal.ThrowExceptionForHR( errorcode );
                errorcode = BuildMoniker( out moniker );
                Marshal.ThrowExceptionForHR( errorcode );
                register = rot.Register( 0, this, moniker );
            }
    
            public void Dispose()
            {
                Close( 0 ); //close and clean up    
            }
    
            //Will look for an existing instance in the ROT and return it
            public static ICOMApplication GetApiInstance()
            {
                Hashtable runningObjects = Ole32.GetRunningObjectTable();
    
                IDictionaryEnumerator rotEnumerator = runningObjects.GetEnumerator();
                while ( rotEnumerator.MoveNext() )
                {
                    string candidateName = (string) rotEnumerator.Key;
                    if ( !candidateName.Equals( "!MyNamespace.ICOMApplication" ) )
                        continue;
    
                    ICOMApplication wbapi = (ICOMApplication ) rotEnumerator.Value;
                    if ( wbapi != null )
                        return wbapi;
                    //TODO: Start the application so it can be added to com and retrieved for use
                }
                return null;
            }
    
            //Builds the moniker used to register and look up the application in the ROT
            private static int BuildMoniker( out IMoniker moniker )
            {
                UnicodeEncoding enc = new UnicodeEncoding();
                string delimname = "!";
                byte[] del = enc.GetBytes( delimname );
                string itemname = "MyNamespace.ICOMApplication";
                byte[] item = enc.GetBytes( itemname );
                return Ole32.CreateItemMoniker( del, item, out moniker );
            }
    
            protected void Close( int i )
            {
                //Deregistering from ROT should be automatic
                //Additional cleanup
                if (ComAppClose != null) ComAppClose("");
            }
    
            ~MyApplication()
            {
                Dispose();
            }
    
            //implement ICOMApplication interface
            private static int i = 0;
            public int GetVal()
            {
                return i++; //test value to return
            }
        }
    }
