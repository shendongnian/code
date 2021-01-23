           private static bool _isConnected;
    
            public static bool isConnected
            {
                get { CheckInternetStatus(); return _isConnected; }
                set { isConnected = value; }
            }
        
