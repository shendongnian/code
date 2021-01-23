    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var enumValue = (Member.UserStatus)((DataRow)value)["Status"];
            if(enumValue == Member.UserStatus.Change)
                return Brushes.Red;
            if(enumValue == Member.UserStatus.Import)
                return Brushes.Blue;
            if(enumValue == Member.UserStatus.Remove)
                return Brushes.Orange;
            if(enumValue == Member.UserStatus.Synced)
                return Brushes.Green;
            else
                return DependencyProperty.UnsetValue;
        }
