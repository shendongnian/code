    public partial class MainWindow : Window 
        {
            public ObservableCollection<xxx> xxxs { get; private set; }
            
            public MainWindow()
            {
                xxxs = new ObservableCollection<xxx>();
                xxxs.Add(new xxx("Mike"));
                xxxs.Add(new xxx("Sarah"));
                
                InitializeComponent();
            }
    
            public class xxx: INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
                private void NotifyPropertyChanged(String info)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(info));
                    }
                }
    
                private bool isChecked = false;
                public bool IsChecked
                {
                    get { return isChecked; }
                    set
                    {
                        if (isChecked == value) return;
                        if (value) FirstName = DateTime.Now.ToString(); else FirstName = string.Empty;
                        isChecked = value;
                        NotifyPropertyChanged("FirstName");
                    }
                }
                public string FirstName { get; private set; }
                public xxx(string firstName) { FirstName = firstName; }
            }
        }
    
            DataContext="{Binding RelativeSource={RelativeSource self}}"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <DataGrid x:Name="MyGrid" ItemsSource="{Binding Path=xxxs}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridCheckBoxColumn Header="CheckBox" Binding="{Binding IsChecked, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                    <DataGridTextColumn Header="Text"  Binding="{Binding FirstName, Mode=OneWay}"/>
                </DataGrid.Columns>
            </DataGrid> 
