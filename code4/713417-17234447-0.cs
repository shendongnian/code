    <Window x:Class="WpfApplication1.DynamicSorting"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
           xmlns:local="clr-namespace:WpfApplication1"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="DynamicSorting" Height="329" Width="610">
        <Window.Resources>
            <local:StringToBrushConverter x:Key="texttobrush"/>
        </Window.Resources>
        <Grid Background="{Binding SelectedBrush,UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="242*" />
                <ColumnDefinition Width="346*" />
            </Grid.ColumnDefinitions>
          
            <ComboBox Height="35" SelectedItem="{Binding SelectedBrush,Mode=TwoWay}"  ItemsSource="{Binding AllBrushes}"  HorizontalAlignment="Left" Margin="25,32,0,0" x:Name="comboBox1" VerticalAlignment="Top" Width="143" />
        </Grid>
    </Window>
 
     public partial class DynamicSorting : Window, INotifyPropertyChanged
        {
            public DynamicSorting()
            {
                InitializeComponent();
                if (FilesList == null)
                    FilesList = new ObservableCollection<FileInfo>();
    
                var files = new System.IO.DirectoryInfo("C:\\Windows\\System32\\").GetFiles();
                foreach (var item in files)
                {
                    FilesList.Add(item);
                }
    
    
                if (AllBrushes == null)
                    AllBrushes = new ObservableCollection<string>();
    
                Type t = typeof(Brushes);
    
                var props = t.GetProperties();
    
                foreach (var item in props)
                {
                    AllBrushes.Add(item.Name);
                }
    
    
    
    
    
                this.DataContext = this;
    
    
    
            }
    
            private SolidColorBrush _SelectedBrush;
    
            public SolidColorBrush SelectedBrush
            {
                get { return _SelectedBrush; }
                set
                {
                    _SelectedBrush = value;
    
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedBrush"));
                }
                    
            }
    
            public ObservableCollection<FileInfo> FilesList { get; set; }
    
            public ObservableCollection<string> AllBrushes { get; set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public class StringToBrushConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null)
                    return Brushes.Transparent;
    
                var colortext = value.ToString();
                var BrushType = typeof(Brushes);
                var brush = BrushType.GetProperty(colortext);
                if (brush != null)
                    return brush;
    
                return Brushes.Transparent;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
