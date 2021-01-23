    <Window x:Class="WpfApplication1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
        xmlns:local="clr-namespace:WpfApplication1"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        Title="MainWindow"
        Width="525"
        Height="350"
        mc:Ignorable="d">
	<Window.DataContext>
		<local:Root/>
	</Window.DataContext>
	<Grid x:Name="LayoutRoot">
		<DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Ch}" CanUserAddRows="False">
			<DataGrid.Columns>
				<DataGridTemplateColumn>
					<DataGridTemplateColumn.CellTemplate>
           				<DataTemplate>
							<Grid>
							<Grid.ColumnDefinitions>
								<ColumnDefinition/>
								<ColumnDefinition/>
							</Grid.ColumnDefinitions>
							<ComboBox  Width="100" ItemsSource="{Binding DataContext.ComboBox1Items, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" x:Name="ComboBox1"/>
							<ComboBox Grid.Column="1" Width="100" ItemsSource="{Binding SelectedItem.Items, ElementName=ComboBox1}" SelectedItem="{Binding TheSettings}" IsEditable="True" IsReadOnly="True"/>
							</Grid>
						</DataTemplate>
        			</DataGridTemplateColumn.CellTemplate>
				</DataGridTemplateColumn>
			</DataGrid.Columns>
		</DataGrid>
	</Grid>
    </Window>
    public class ComboBox1Item
	{
		public string Label { get; set; }
		public List<string> Items { get; set; }
		public override string ToString()
		{
			return this.Label;
		}
	}
    public class Root
	{
		public List<Channel> Ch { get; set; }
		public List<ComboBox1Item> ComboBox1Items { get; set; }
		public Root()
		{
			this.Ch = new List<Channel>(){
				new Channel(){ TheSettings = "Settings1"},
				new Channel(){ TheSettings = "Settings2"},
			};
			this.ComboBox1Items = new List<ComboBox1Item>{
				new ComboBox1Item(){ Label = "Item1",
					Items = new List<string>(){ "Settings1", "Settings2"}
				},
				new ComboBox1Item(){ Label = "Item2",
					Items = new List<string>(){ "Settings3", "Settings4"}
				}
			};
		}
	}
