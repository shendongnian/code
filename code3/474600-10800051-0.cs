    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    SolidColorBrush brush = new SolidColorBrush(Colors.Black);    
                     
                    Double doubleValue = 0.0;
                    if (value != null)
                    {
                        mydatatype data = value as mydatatype;
                     //your logic goes here and also can play here with your dataitem. 
                            if (Double.TryParse(data.CollD.ToString(), out doubleValue))
                            {
                                if (doubleValue < 0)
                                    brush = new SolidColorBrush(Colors.Red);
                            }        
                    }
                    return brush;
                }
