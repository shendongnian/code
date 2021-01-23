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
        private void   DoGPSStuff()
        {
            //s
        }
        GPSLoc Loc;
    }
