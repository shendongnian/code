    <Window x:Class="WPFTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:converters="clr-namespace:WPFTest"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <converters:MyConverter x:Key="converter"/>
        </Window.Resources>
            <Grid>
            <ListBox ItemsSource="{Binding Items}" Margin="0,0,360,0" x:Name="list">
                
            </ListBox>
            <TextBox Text="{Binding  Path=SelectedValue,Converter={StaticResource converter},ConverterParameter=0, ElementName=list}" Height="25" Width="100"/>
            <TextBox Text="{Binding  Path=SelectedValue,Converter={StaticResource converter}, ConverterParameter=1,ElementName=list}" Height="25" Width="100" Margin="208,189,209,106"/>
    
        </Grid>
    </Window>
     public partial class MainWindow : Window
        {
            public List<string> Items { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                if (Items == null)
                    Items = new List<string>();
                Random ran = new Random();
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(ran.Next(1, 5) + "x" + ran.Next(5, 10));
                }
    
                this.DataContext = this;
            }
    
        }
    
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null)
                    return "Null";
    
                var values = value.ToString().Split(new string[] { "x" }, StringSplitOptions.None);
    
                int x = 0;
                if (int.TryParse(parameter.ToString(), out x))
                {
                    return values[x].ToString();
                }
    
    
                return "N/A";
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
