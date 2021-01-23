    string color = textBox1.Text;
    // best, using Color's static method
    Color red1 = Color.FromName(color);
    
    // using a ColorConverter
    TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color)); // ..or..
    TypeConverter tc2 = new ColorConverter();
    Color red2 = (Color)tc.ConvertFromString(color);
    
    // using Reflection on Color or Brush
    Color red3 = (Color)typeof(Color).GetProperty(color).GetValue(null, null);
    
    // in WPF you can use a BrushConverter
    SolidColorBrush redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(color);
