    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var mainborder = sender as Border;
			double x = e.GetPosition(mainborder).X;
			double val = 1 - (mainborder.ActualWidth - x) / mainborder.ActualWidth;
			slider.Value = val * (slider.Maximum - slider.Minimum) + slider.Minimum;
		}
	}
	public class SliderValueConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double val = (double)values[0];
			double min = (double)values[1];
			double max = (double)values[2];
			double sliderWidth = (double)values[3];
			return sliderWidth * (val - min) / (max - min);
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
    <Window x:Class="WpfTest.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:WpfTest"
        Title="MainWindow" Height="650" Width="825">
	<Window.Resources>
		<local:SliderValueConverter x:Key="sliderValueConverter"/>
	</Window.Resources>
	<StackPanel>
		<Slider Maximum="200" Minimum="100" Name="slider">
			<Slider.Template>
				<ControlTemplate TargetType="{x:Type Slider}">
					<Border Background="Silver" Height="30" MouseDown="Border_MouseDown">
						<Border Background="Green" HorizontalAlignment="Left">
							<Border.Width>
								<MultiBinding Converter="{StaticResource sliderValueConverter}">
									<Binding RelativeSource="{RelativeSource TemplatedParent}" Path="Value"/>
									<Binding RelativeSource="{RelativeSource TemplatedParent}" Path="Minimum"/>
									<Binding RelativeSource="{RelativeSource TemplatedParent}" Path="Maximum"/>
									<Binding RelativeSource="{RelativeSource TemplatedParent}" Path="ActualWidth"/>
								</MultiBinding>
							</Border.Width>
						</Border>
					</Border>
				</ControlTemplate>
			</Slider.Template>
		</Slider>
	</StackPanel>
