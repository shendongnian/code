    public class ColorSettingsSequencesSequence : ViewModelBase, IDataErrorInfo
    {
        #region Declarations
        private string startColor;
        private string startTemperature;
        private string endTemperature;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the start color.
        /// </summary>
        /// <value>
        /// The start color.
        /// </value>
        public string StartColor
        {
            get
            {
                return this.startColor;
            }
            set
            {
                this.startColor = value;
                OnPropertyChanged("StartColor");
            }
        }
        /// <summary>
        /// Gets or sets the start temperature.
        /// </summary>
        /// <value>
        /// The start temperature.
        /// </value>
        public string StartTemperature
        {
            get
            {
                return this.startTemperature;
            }
            set
            {
                this.startTemperature = value;
                OnPropertyChanged("StartTemperature");
            }
        }
        /// <summary>
        /// Gets or sets the end temperature.
        /// </summary>
        /// <value>
        /// The end temperature.
        /// </value>
        public string EndTemperature
        {
            get
            {
                return this.endTemperature;
            }
            set
            {
                this.endTemperature = value;
                OnPropertyChanged("EndTemperature");
            }
        }
        #endregion
        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error 
        {
            get 
            {
                return "";
            } 
        }
        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get 
            {
                if (columnName.Equals("StartTemperature"))
                {
                    if (string.IsNullOrEmpty(this.StartTemperature))
                    {
                        return "Please enter a start temperature";
                    }
                }
                if (columnName.Equals("EndTemperature"))
                {
                    if (string.IsNullOrEmpty(this.EndTemperature))
                    {
                        return "Please enter a end temperature";
                    }
                }
                return "";
            }
        }
    }
