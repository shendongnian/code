    public BitmapImage Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
    { 
        var empImage = new BitmapImage(); 
        empImage.CreateOptions = BitmapCreateOptions.None; 
        empImage.SetSource(new MemoryStream(((MeetPoint_B2C.ServiceReference1.Binary)value).Bytes); ); 
        return empImage; 
    } 
