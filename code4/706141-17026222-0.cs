     <DatePicker x:Name="datepicker" Text="{Binding  RelativeSource={RelativeSource Self}, Converter={StaticResource DateConverter}, Path=SelectedDate, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, ValidatesOnDataErrors=False}">
                <DatePicker.Style>
                    <Style TargetType="DatePicker">
                        <Style.Triggers>
                            <Trigger Property="SelectedDate" Value="{x:Null}">
                                <Setter Property="Text" Value="Select A Date"/>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </DatePicker.Style>
            </DatePicker>
   
     public class DateConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null)
                    return null;
    
                if (((DateTime)value).ToShortDateString() == "31/12/2999")
                    return null;
    
                DateTime returnVal;
    
                if (DateTime.TryParse(value.ToString(), out returnVal))
                {
    
                    if (returnVal <= DateTime.Today) // to check only
                        return returnVal;
                    //else if (returnVal != DateTime.MinValue)
                    //    return returnVal;
                    else
                        return null;
                }
                else
                    return null;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
    
    
                if (value == null)
                    return null;
    
                DateTime val;
                if (value.ToString() == "31/12/2999")
                    return null;
    
                if (DateTime.TryParse(value.ToString(), out val))
                    return val;
                else
                    return null;
    
    
            }
    
        }
