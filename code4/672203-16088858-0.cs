    public class WireLessDevice
            { // base class
                virtual void ParseMessage(); // inserts data into the wireless device object
            }
    
            public class WiFi : WireLessDevice
            { // derived class
                override void ParseMessage()
                {
                    //DO something with loc
                }
                GPSLoc Loc;
            }
