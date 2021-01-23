    public class LocationtoEquipmentCOnverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter,   System.Globalization.CultureInfo culture)
    {
        MegaWidget MWidget = (MegaWidget)value;
        Location loc = MWidget.Locations[(string)parameter];
        
        //Refers to Class "Content" used in loc.Contents collection. I do not know what the name that you have used
        foreach (Content item in loc.Contents)
            {
                item.Name += "***";
            }
        return loc.Contents;
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    }
