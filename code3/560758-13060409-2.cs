    namespace WpfApplication {
    
        public class Thing
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    
        public partial class MainWindow : Window
        {
            public MainWindow() {
                InitializeComponent();
                DataContext = new Thing[] {new Thing {Name = "A", Date = DateTime.Today}};
            }
    
            private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
                if (e.PropertyName == "Date")
                {
                    var templateColumn = new DataGridTemplateColumn();
                    templateColumn.Header = "Date";
                    templateColumn.CellTemplate = (DataTemplate) Resources["DateTemplate"];
                    templateColumn.CellEditingTemplate = (DataTemplate) Resources["DateEditTemplate"];
                    e.Column = templateColumn;
                }
            }
        }
    }
    <Window x:Class="WpfApplication.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <DataTemplate x:Key="DateTemplate">
                <TextBlock Text="{Binding Date, StringFormat='d'}" />
            </DataTemplate>
            <DataTemplate x:Key="DateEditTemplate">
                <DatePicker SelectedDate="{Binding Date, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
            </DataTemplate>
        </Window.Resources>
        <Grid>
            <DataGrid AutoGenerateColumns="True" ItemsSource="{Binding}" AutoGeneratingColumn="DataGrid_AutoGeneratingColumn" />
        </Grid>
    </Window>
