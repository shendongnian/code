    class BooleanToVisibilityConverter : IValueConverter
    {
        public void Convert(object value, blah blah blah...)
        {
            if(value is bool)
            {
                if((bool)value) return Visibility.Visible;
                    
                return Visibility.Collapsed;
            }
            return null;
        }
    }
