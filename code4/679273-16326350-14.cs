    namespace COMTest
    {
        //extend both the com app and its events and use the event sink to get the events
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        public sealed class MyAppDotNetWrapper, ICOMEvents, ICOMApplication
        {
            private ICOMApplication comapp;
            public MyAppDotNetWrapper()
            {
                StartEventSink()
            }
            //Manage the sink events
            private void StartEventSink()
            {
                //get the instance of the app;
                comapp = WBApplicationApi.GetApiInstance();
                if (comapp != null)
                {
                    serverconnected = true;
                    //Start the event sink
                    IConnectionPointContainer connectionPointContainer = (IConnectionPointContainer) comapp;
                    Guid comappEventsInterfaceId = typeof (ICOMWBBondPointApplicationEvents).GUID;
                    connectionPointContainer.FindConnectionPoint(ref comappEventsInterfaceId, out connectionPoint);
                    connectionPoint.Advise(this, out cookie);
                }
            }
            private void StopEventSink()
            {
                if (serverconnected)
                {
                    //unhook the event sink
                    connectionPoint.Unadvise(cookie);
                    connectionPoint = null;
                }
            }
            //Implement ICOMApplication methods
            public int GetVal()
            {
                return comapp.GetVal();
            }
            //receive sink events and forward
            public event ComEvent WBBondPointCloseEvent;
            public void WBBondPointClose(string s)
            {
                serverconnected = false;
                WBBondPointCloseEvent(s);
            }
            private ICOMWBBondPointApplication comapp;
            IConnectionPoint connectionPoint;
            private int cookie;
            private bool serverconnected;
        }
    }
