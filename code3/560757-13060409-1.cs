    namespace WpfApplication {
    
        public class Thing
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
                DataContext = new Thing[] {new Thing {Name = "A", Date = DateTime.Today}};
            }
        }
    }
    <Window x:Class="WpfApplication.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding}">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                    <DataGridTemplateColumn Header="Date">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Date, StringFormat='d'}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                        <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <DatePicker SelectedDate="{Binding Date, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </Window>
