    namespace ole32
    {
        public class Ole32
        {
            [DllImport( "Ole32.Dll" )]
            public static extern int CreateBindCtx( int reserved, out IBindCtx
                bindCtx );
    
            [DllImport( "oleaut32.dll" )]
            public static extern int RegisterActiveObject( [MarshalAs( UnmanagedType.IUnknown )] object punk,
                 ref Guid rclsid, uint dwFlags, out int pdwRegister );
    
            [DllImport( "ole32.dll", EntryPoint = "GetRunningObjectTable" )]
            public static extern int GetRunningObjectTable( int reserved, out IRunningObjectTable ROT );
    
            [DllImport( "ole32.dll", EntryPoint = "CreateItemMoniker" )]
            public static extern int CreateItemMoniker( byte[] lpszDelim, byte[] lpszItem, out IMoniker ppmk );
    
            /// <summary>
            /// Get a snapshot of the running object table (ROT).
            /// </summary>
            /// <returns>A hashtable mapping the name of the object
            //     in the ROT to the corresponding object</returns>
    
            public static Hashtable GetRunningObjectTable()
            {
                Hashtable result = new Hashtable();
    
                IntPtr numFetched = IntPtr.Zero;
                IRunningObjectTable runningObjectTable;
                IEnumMoniker monikerEnumerator;
                IMoniker[] monikers = new IMoniker[1];
    
                GetRunningObjectTable( 0, out runningObjectTable );
                runningObjectTable.EnumRunning( out monikerEnumerator );
                monikerEnumerator.Reset();
    
                while ( monikerEnumerator.Next( 1, monikers, numFetched ) == 0 )
                {
                    IBindCtx ctx;
                    CreateBindCtx( 0, out ctx );
    
                    string runningObjectName;
                    monikers[0].GetDisplayName( ctx, null, out runningObjectName );
    
                    object runningObjectVal;
                    runningObjectTable.GetObject( monikers[0], out runningObjectVal );
    
                    result[runningObjectName] = runningObjectVal;
                }
    
                return result;
            }
        }
    }
