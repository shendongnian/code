    public class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        // Fields
        private PropertyChangedEventHandler propertyChanged;
        // Events
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                PropertyChangedEventHandler handler2;
                PropertyChangedEventHandler propertyChanged = this.propertyChanged;
                do
                {
                    handler2 = propertyChanged;
                    PropertyChangedEventHandler handler3 = (PropertyChangedEventHandler)Delegate.Combine(handler2, value);
                    propertyChanged = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, handler3, handler2);
                }
                while (propertyChanged != handler2);
            }
            remove
            {
                PropertyChangedEventHandler handler2;
                PropertyChangedEventHandler propertyChanged = this.propertyChanged;
                do
                {
                    handler2 = propertyChanged;
                    PropertyChangedEventHandler handler3 = (PropertyChangedEventHandler)Delegate.Remove(handler2, value);
                    propertyChanged = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, handler3, handler2);
                }
                while (propertyChanged != handler2);
            }
        }
        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (propertyNames == null)
            {
                throw new ArgumentNullException("propertyNames");
            }
            foreach (string str in propertyNames)
            {
                this.RaisePropertyChanged(str);
            }
        }
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName<T>(propertyExpression);
            this.RaisePropertyChanged(propertyName);
        }
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.propertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region IDataErrorInfo & Validation Members
        /// <summary>
        /// List of Property Names that should be validated
        /// </summary>
        //protected List<string> ValidatedProperties = new List<string>();
        #region Validation Delegate
        public delegate string ValidationDelegate(
            object sender, string propertyName);
        private List<ValidationDelegate> _validationDelegates =
            new List<ValidationDelegate>();
        public void AddValidationDelegate(ValidationDelegate func)
        {
            _validationDelegates.Add(func);
        }
        public void RemoveValidationDelegate(ValidationDelegate func)
        {
            if (_validationDelegates.Contains(func))
                _validationDelegates.Remove(func);
        }
        #endregion // Validation Delegate
        public virtual string GetValidationError(string propertyName)
        {
            // If user specified properties to validate, check to see if this one exists in the list
            //if (ValidatedProperties.IndexOf(propertyName) < 0)
            //{
            //    return null;
            //}
            string s = null;
            //switch (propertyName)
            //{
            //}
            foreach (var func in _validationDelegates)
            {
                s = func(this, propertyName);
                if (s != null)
                    return s;
            }
            return s;
        }
        string IDataErrorInfo.Error { get { return null; } }
        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }
        //public bool IsValid
        //{
        //    get
        //    {
        //        return (GetValidationError() == null);
        //    }
        //}
        //public string GetValidationError()
        //{
        //    string error = null;
        //    if (ValidatedProperties != null)
        //    {
        //        foreach (string s in ValidatedProperties)
        //        {
        //            error = GetValidationError(s);
        //            if (error != null)
        //            {
        //                return error;
        //            }
        //        }
        //    }
        //    return error;
        //}
        #endregion // IDataErrorInfo & Validation Members
    }
