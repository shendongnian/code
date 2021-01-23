    [Flags]
    enum ReturnCode : uint
    {
        S_OK = 0, S_FALSE = 1, REGDB_E_CLASSNOTREG = 0x80040154, CLASS_E_NOAGGREGATION = 0x80040110, E_NOINTERFACE = 0x80004002, E_POINTER = 0x80004003
    }
    [Flags]
    enum CLSCTX : uint
    {
        CLSCTX_INPROC_SERVER = 0x1, CLSCTX_INPROC_HANDLER = 0x2, CLSCTX_LOCAL_SERVER = 0x4,
        //... //others
        CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER
    }
    /// <summary>
    /// Sink Class implementig COM Server outgoing interface SWLMLib.ISWMgrEvents 
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    class MySink : SWLMLib.ISWMgrEvents
    {
        public void FeatureAboutToExpire(SWLMLib.IFeature pFeature, int HoursRemained)
        {
            Console.WriteLine("{0} FeatureAboutToExpire: Feature {1} Hours={2}", DateTime.Now, pFeature.Code, HoursRemained);
            Marshal.ReleaseComObject(pFeature); //WTF??? Without this line COM Server object is not released!
        }
        public void FeatureExpired(SWLMLib.IFeature pFeature)
        {
            Console.WriteLine("FeatureExpired: Feature {0}", pFeature.Code);
            Marshal.ReleaseComObject(pFeature); //Without this line COM Server object is not released!
        }
    }
    class Program
    {
        //Import "CoCreateInstance" to play with run context of created COM-object (3rd parameter)
        [DllImport("ole32.dll", EntryPoint = "CoCreateInstance", CallingConvention = CallingConvention.StdCall)]
        static extern UInt32 CoCreateInstance([In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
           IntPtr pUnkOuter, UInt32 dwClsContext, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
           [MarshalAs(UnmanagedType.IUnknown)] out object rReturnedComObject);
        static void Main(string[] args)
        {
            try
            {
                Guid SWMgrClassObjectGuid = typeof(SWLMLib.SWMgrClass).GUID;    //{8EAAFAD7-73F8-403B-A53B-4400E16D8EDF}
                Guid IUnknownGuid = new Guid("00000000-0000-0000-C000-000000000046"); //Can it be written in more pretty style?
                SWLMLib.ISWMgr lintfSWLMgr = null;
                /* This will create IN-PROC Server because, it seems CoCreateInstance will be invoked with CLSCTX_INPROC_SERVER flag settled
                Type type = Type.GetTypeFromCLSID(SWMgrClassObjectGuid), true);
                object instance0 = Activator.CreateInstance(type);
                lintfSWLMgr = (instance0 as SWLMLib.ISWMgr); */
                Guid Ev1 = typeof(ISWMgrEvents).GUID;
                object instance = null;
                unsafe
                {
                    UInt32 dwRes = CoCreateInstance(SWMgrClassObjectGuid,
                                                    IntPtr.Zero,
                                                    (uint)(CLSCTX.CLSCTX_LOCAL_SERVER), //if OR with CLSCTX_INPROC_SERVER then INPROC Server will be created, because of DLL COM Server
                                                    IUnknownGuid,
                                                    out instance);
                    if (dwRes != 0)
                    {
                        int iError = Marshal.GetLastWin32Error();
                        Console.WriteLine("CoCreateInstance Error = {0}, LastWin32Error = {1}", dwRes, iError);
						return;
                    }
                    lintfSWLMgr = (instance as SWLMLib.ISWMgr);
                }
                if (lintfSWLMgr != null)
                {
                    //lintfSWLMgr.InitializeMethod(...); //Initialize object
                    //Find Connection Point for Events
                    Guid ISWMgrEventsGuid = typeof(SWLMLib.ISWMgrEvents).GUID;      //{C13A9D38-4BB0-465B-BF4A-487F371A5538} Interface for Evenets Handling
                    IConnectionPoint lCP = null;
                    IConnectionPointContainer lCPC = (instance as IConnectionPointContainer);
                    lCPC.FindConnectionPoint(ref ISWMgrEventsGuid, out lCP);
                    MySink lSink = new MySink();
                    Int32 dwEventsCookie;
                    lCP.Advise(lSink, out dwEventsCookie);
                    Console.WriteLine("Waiting for Events Handling...");
                    Console.WriteLine("Press ENTER to Exit...");
                    Console.ReadLine(); // Until Eneter is not hit, the events arrive properly
                    //Here starting to Unsubscribe for Events and Com Objects CleanUP
					lCP.Unadvise(dwEventsCookie);
                    Marshal.ReleaseComObject(lCP); 
                    Marshal.ReleaseComObject(lintfSWLMgr); 
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                throw;
            }
        }
    }
