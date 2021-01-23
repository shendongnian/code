    public class ViewModel:INotifyPropertyChanged
        {
            private string initialText;
            public ViewModel()
            {
                Text = "ABCD";
                initialText = Text;
                DefaultBorder = true;
            }
            private string text;
            public string Text
            {
                get { return text; }
                set { text = value;
                if (value == initialText)
                    DefaultBorder = true;
                else
                    DefaultBorder = false;
                    Notify("Text"); }
            }
            private bool defaultBorder;
            public bool DefaultBorder
            {
                get { return defaultBorder; }
                set { defaultBorder = value; Notify("DefaultBorder"); }
            }
            private void Notify(string propertyName)
            {
                if(PropertyChanged!=null)
                    PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null && value is bool && !(bool)value)
                    return new SolidColorBrush(Colors.Orange);
                else
                    return new SolidColorBrush(Colors.Navy); //Or default whatever you want
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
        <Window.Resources>
        <local:MyConverter x:Key="MyConverter"/>
    </Window.Resources>
    <Grid>
        <TextBox BorderThickness="4" BorderBrush="{Binding DefaultBorder, Converter={StaticResource MyConverter}}" Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}"/>
    </Grid>
