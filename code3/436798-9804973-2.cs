    <Window x:Class="ConverterCombinerTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:ConverterCombinerTest"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
             <ListView ItemsSource="{Binding LvItems}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBlock Text="{Binding Path=Key}"/>
                            <TextBlock Text=":"/>
                            <TextBlock Text="{Binding Path=Value}"/>
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </Grid>
    </Window>
    public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                LvItems = new ObservableCollection<KeyValuePair<string, object>>();
                LvItems.Add(new KeyValuePair<string, object>("Idx", 5));
                LvItems.Add(new KeyValuePair<string, object>("Ido", 12));
            }
    
            public ObservableCollection<KeyValuePair<string, object>> LvItems { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(String _Prop)
            {
                PropertyChangedEventHandler handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(_Prop));
                }
            }
        }
