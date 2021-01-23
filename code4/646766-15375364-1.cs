    public class MyWindow : Window
    {
        #region Properties
        public List<Vehicle> CarList
        {
            get
            {
                return this._carList;
            }
        }
        private List<Vehicle> _carList = new List<Vehicle>();
        #endregion
        /* window stuff */
    }
