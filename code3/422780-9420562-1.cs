    public object Convert(object value, Type targetType, object parameter, 
        System.Globalization.CultureInfo culture)   
    {
         var trucks = (float)value;
                   
        
         if (trucks == 1)
             return new BitmapImage("Resource File Path");
         else if (trucks == 2.5)
             return new BitmapImage("Resource File for 2.5 value");
         else if (trucks == 3)
             return new BitmapImage("Resource File for 3 trucks value");
         else
             return null;
    }
