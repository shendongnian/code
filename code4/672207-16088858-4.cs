    public class WireLessDevice
    { // base class
        protected virtual void ParseMessage()
        {
            // Do common stuff in here
        }
    }
    
    public class WiFi : WireLessDevice
    { // derived class
        override void ParseMessage()
        {
            base.ParseMessage();//Call this if you need some operations from base impl.
            DoGPSStuff();
        }
        private void DoGPSStuff()
        {
            //some gps stuff
        }
        GPSLoc Loc;
    }
