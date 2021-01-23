    public static class RegionAndLanguageHelper
    {
        #region Constants
        private const int GEO_FRIENDLYNAME = 8;
       
        #endregion
        #region Private Enums
        private enum GeoClass : int
        {
            Nation = 16,
            Region = 14,
        };
        #endregion
        #region Win32 Declarations
        [DllImport("kernel32.dll", ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int GetUserGeoID(GeoClass geoClass);
        [DllImport("kernel32.dll")]
        private static extern int GetUserDefaultLCID();
        [DllImport("kernel32.dll")]
        private static extern int GetGeoInfo(int geoid, int geoType, StringBuilder lpGeoData, int cchData, int langid);
        #endregion
        #region Public Methods
        /// <summary>
        /// Returns machine current location as specified in Region and Language settings.
        /// </summary>
        public static string GetMachineCurrentLocation()
        {
            int geoId = GetUserGeoID(GeoClass.Nation); ;
            int lcid = GetUserDefaultLCID();
            StringBuilder locationBuffer = new StringBuilder(100);
            GetGeoInfo(geoId, GEO_FRIENDLYNAME, locationBuffer, locationBuffer.Capacity, lcid);
            return locationBuffer.ToString().Trim();
        }
        #endregion
    }
