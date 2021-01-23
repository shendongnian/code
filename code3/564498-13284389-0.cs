    public enum Mode:byte
    {
        /*
         +-------+--------------------------+
         | Value | Meaning                  |
         +-------+--------------------------+
         | 0     | reserved                 |
         | 1     | symmetric active         |
         | 2     | symmetric passive        |
         | 3     | client                   |
         | 4     | server                   |
         | 5     | broadcast                |
         | 6     | NTP control message      |
         | 7     | reserved for private use |
         +-------+--------------------------+
         */
    
        Resevered = 0,
        SymmetricActive = 1,
        SymmetricPassive = 2,
        Client = 3,
        Server = 4,
        Broadcast = 5,
        ControlMessage = 6,
        PrivateUse = 7
    }
