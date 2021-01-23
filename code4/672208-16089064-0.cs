    class WireLessDevice
    {
        protected virtual bool ParseMessage(byte[] message]
        {
            // Inspect message and handle the known ones
            return true; // Only if message parsed, otherwise false
        }
    }
    
    class WiFi : WireLessDevice
    {
        GPSLoc Loc;
    
        protected override bool ParseMessage(byte[] message]
        {
            bool messageParsed = base.ParseMessage(message)
            if (!messageParsed)
            {
                // Handle device specific message with GPSLoc
                Loc = ...
            }
        }
    }
