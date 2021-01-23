    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        // INPC implementation is omitted
        public string Text1
        {
            get { return text1; }
            set
            {
                if (text1 != value)
                {
                    text1 = value;
                    OnPropertyChanged("Text1");
                }
            }
        }
        private string text1;
        
        public string Text2
        {
            get { return text2; }
            set
            {
                if (text2 != value)
                {
                    text2 = value;
                    OnPropertyChanged("Text2");
                }
            }
        }
        private string text2;
        #region IDataErrorInfo Members
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get 
            {
                if (columnName == "Text1" && string.IsNullOrEmpty(Text1))
                    return "Text1 cannot be empty.";
                return null;
            }
        }
        #endregion
    }
