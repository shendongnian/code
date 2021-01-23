        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState( out int Description, int ReservedValue ) ;
        
        public static bool IsConnectedToInternet( )
        {
            try
            {
                int Desc;
                return InternetGetConnectedState(out Desc, 0);
            }
            catch 
            {
                return false;
            }
        }
