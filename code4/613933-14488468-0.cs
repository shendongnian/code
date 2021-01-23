    class MyReallyBigClass : IAwesome, INotAsAwesome
    {
        #region Public Properties
        public string Test { get; set; }
        // ..
        #endregion
        #region IAwesome Implementation
        public void IAwesome.BeAwesome()
        {
            // ..
        }
        public int IAwesome.AwesomeLevel()
        {
            // ..
        }
        #endregion
        #region INotAsAwesome Implementation [[...]]
        #region Internal Fields
        private int _whatever;
        // ..
        #endregion
    }
