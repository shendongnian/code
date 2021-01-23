    public static class ApplicationData
    {
        #region Properties
        public static List<Vehicle> CarList
        {
            get
            {
                return ApplicationData._carList;
            }
        }
        private static List<Vehicle> _carList = new List<Vehicle>();
        #endregion
    }
