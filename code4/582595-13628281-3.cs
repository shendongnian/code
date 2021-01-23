    public class ViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged values
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		public List<Dummy> Elements { get; set; }
		public ViewModel()
		{
			this.Elements = new List<Dummy>(){
				new Dummy() { CanSelect =true, MyProperty = "Element1"},
				new Dummy() { CanSelect =false, MyProperty = "Element2"},
				new Dummy() { CanSelect =true, MyProperty = "Element3"},
				new Dummy() { CanSelect =false, MyProperty = "Element4"},
				new Dummy() { CanSelect =true, MyProperty = "Element5"},
				new Dummy() { CanSelect =true, MyProperty = "Element6"},
				new Dummy() { CanSelect =true, MyProperty = "Element7"},
				new Dummy() { CanSelect =true, MyProperty = "Element8"},
				new Dummy() { CanSelect =false, MyProperty = "Element9"},
			};
		}
	}
	public class Dummy
	{
		public bool CanSelect { get; set; }
		public string MyProperty { get; set; }
		public override string ToString()
		{
			return this.MyProperty;
		}
	}
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
	<Window.Resources>
		<Style x:Key="DataGridRowStyle" TargetType="{x:Type DataGridRow}">
			<Setter Property="local:DataGridRowEx.CanSelect" Value="{Binding CanSelect}" />
		</Style>
	</Window.Resources>
	<Window.DataContext>
		<local:ViewModel />
	</Window.DataContext>
	<Grid x:Name="LayoutRoot">
		<DataGrid ItemsSource="{Binding Elements}"
		          RowStyle="{DynamicResource DataGridRowStyle}"
		          SelectionUnit="FullRow" />
	</Grid>
    </Window>
