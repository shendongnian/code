    public class MyViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public MyViewModel()
        {
            Value = 30;
        }
        private double _value;
        [Range(1, 80, ErrorMessage = "out of range")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                ValidationMessageSetter("Value", value);
            }
        }
        private void ValidationMessageSetter(string propertyName, object value)
        {
            Notify(propertyName);
            string validationresult = ValidateProperty(propertyName, value);
            if (!string.IsNullOrEmpty(validationresult) && !_dataErrors.ContainsKey(propertyName))
                _dataErrors.Add(propertyName, validationresult);
            else if (_dataErrors.ContainsKey(propertyName))
                    _dataErrors.Remove(propertyName);
        
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        private void Notify(string str)
        { 
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(str));
        }
        private string ValidateProperty(string propertyName,object value)
        {
            var results = new List<ValidationResult>(2);
            string error = string.Empty;
            bool result = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName
                },
                results);
            if (!result && (value == null || ((value is int || value is long) && (int)value == 0) || (value is decimal && (decimal)value == 0)))
                return null;
            if (!result)
            {
                ValidationResult validationResult = results.First();
                error = validationResult.ErrorMessage;
            }
            return error;    
        }
        #region IDataErrorInfo Members
        private Dictionary<string, string> _dataErrors = new Dictionary<string, string>();
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                if (_dataErrors.ContainsKey(columnName))
                    return _dataErrors[columnName];
                else
                    return null;
            }
        }
        #endregion
    }
    <TextBox Text="{Binding Value, Mode=TwoWay, ValidatesOnDataErrors=True, UpdateSourceTrigger=PropertyChanged}"/>
