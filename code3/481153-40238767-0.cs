	<Window x:Class="WpfApplication15.MainWindow"
			xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
			xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
			xmlns:tz="http://schemas.abtsoftware.co.uk/transitionz"
			xmlns:wpfApplication15="clr-namespace:WpfApplication15"
			mc:Ignorable="d"
			Title="MainWindow" Height="350" Width="525">
		<Window.Resources>
			<BooleanToVisibilityConverter x:Key="b2vc"></BooleanToVisibilityConverter>
			<wpfApplication15:BluParamsWhenTrueConverter x:Key="bpc" From="0" To="10" Duration="200"></wpfApplication15:BluParamsWhenTrueConverter>
		</Window.Resources>
		<Grid>
			<CheckBox x:Name="CheckBox" Content="Is Visible?" IsChecked="False"></CheckBox>
			<TextBlock Foreground="#AAA" Margin="10" TextWrapping="Wrap" Text="Lorem ipsum .. TODO insert a lot of text here "
					   tz:Transitionz.Blur="{Binding ElementName=CheckBox, Path=IsChecked, Converter={StaticResource bpc}}"/>
			<TextBlock Text="Hello World!" FontSize="44" HorizontalAlignment="Center" VerticalAlignment="Center"
				Visibility="Collapsed"
				tz:Transitionz.Opacity="{tz:OpacityParams From=0, To=1, Duration=200, TransitionOn=Visibility}"
				tz:Transitionz.Translate="{tz:TranslateParams From='10,0', To='0,0', Duration=200, TransitionOn=Visibility}"
				tz:Transitionz.Visibility="{Binding ElementName=CheckBox, Path=IsChecked, Converter={StaticResource b2vc}}"/>
		</Grid>
	</Window>
	using System;
	using System.Globalization;
	using System.Windows.Data;
	using SciChart.Wpf.UI.Transitionz;
	namespace WpfApplication15
	{
		public class BluParamsWhenTrueConverter : IValueConverter
		{
			public double Duration { get; set; }
			public double From { get; set; }
			public double To { get; set; }
			public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			{
				return ((bool)value) ? 
					new BlurParams() {  Duration = Duration, From = From, To = To, TransitionOn = TransitionOn.Once} : 
					new BlurParams() { Duration = 200, From = To, To = From, TransitionOn = TransitionOn.Once};
			}
			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException();
			}
		}
	}
