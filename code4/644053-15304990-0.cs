    namespace Practise
    {
        /// <summary>
        /// Interaction logic for DropdownGrid.xaml
        /// </summary>
        public partial class DropdownGrid : Window
        {
            public DropdownGrid()
            {
                InitializeComponent();
                List<MainContent> objMainContent = new List<MainContent>{
                    new MainContent { Subject = "Maths", Status = "Open" },
                    new MainContent { Subject = "Science", Status = "Closed" },
                    new MainContent { Subject = "Computers" , Status = "high"}
                };
    
                DemoGrid.ItemsSource = objMainContent; 
            }
        }
    
        public class MainContent
        {
            public string Subject { get; set; }
            public string Status { get; set; }
        }
    
        public class StatusList : List<string>
        {
            public StatusList()
            {
                this.Add("Open");
                this.Add("Closed");
                this.Add("High");
                this.Add("Low");
            }
        }
    }
    <Window x:Class="Practise.DropdownGrid"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:staticData="clr-namsespace:Practise"
            Title="DropdownGrid" Height="700" Width="600" WindowState="Maximized" Background="#f0f0f0">
        <Window.Resources>
            <staticData:StatusList x:Key="StatusList" />  // Error of Namespace
        </Window.Resources>
    
        <StackPanel VerticalAlignment="Center" Width="300">
    
            <DataGrid AutoGenerateColumns="False" Height="366" Name="DemoGrid" ItemsSource="{Binding objLabel}" >
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Subject}" Header="Demo Label" Width="*">
    
                    </DataGridTextColumn>
                    <DataGridTemplateColumn Header="Drop Down">
                        <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <ComboBox Name="ComboBoxName" ItemsSource="{StaticResource StatusList}" SelectedItem="{Binding Status}"  >                                
    
                                </ComboBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </StackPanel>
    </Window>
