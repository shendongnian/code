    public class MultiBindingConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert(object[] values, Type targetType,
        object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue
               && values[0] != null && values[1] != null)
            {
                var value1 = (int)values[0];
                var value2 = (bool)values[1];
                var result = (value1 > 1 && value2);
                if (result)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public object[] ConvertBack
             (object value, Type[] targetTypes,
              object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public class Student : INotifyPropertyChanged
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public bool Active
        {
            get;
            set;
        }
        public Student()
        { }
        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
