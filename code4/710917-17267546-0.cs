    #region cTor
        private string _propertyName;
        private Func<string, string> _validationFunc;
        public myWrapper(string propertyName, object original, Func<string, string> validationFunc)
        {
            _propertyName = propertyName;
            _validationFunc = validationFunc;
            currentValue = original;
            currentOriginal = original.Copy(); // creates an deep Clone
        }
        #endregion
