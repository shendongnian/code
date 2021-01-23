    <!-- 1. .Xaml file code (Notice the `SizeToContent` usage in `Window` and that the binding is to `ActualWidth` property for `Textbox` control): -->
    <Window x:Class="GridTest.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:local="clr-namespace:GridTest"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            Title="MainWindow"
            d:DesignHeight="350"
            d:DesignWidth="525"
            SizeToContent="WidthAndHeight"
            mc:Ignorable="d">
        <Grid>
            <Grid.Resources>
                <local:FourWidthConverter x:Key="FourWidthConv" />
            </Grid.Resources>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <TextBlock Name="tb"
                       Grid.Column="0"
                       Text="Auto Text, change at design time to see changes in Width" />
            <TextBox Name="tx"
                     Grid.Column="1"
                     Width="{Binding ElementName=tb,
                                     Path=ActualWidth,
                                     Converter={StaticResource FourWidthConv}}"
                     Text="4 * col 1 width displaying Text in SizetoContentWindow" />
        </Grid>
    </Window>
    2. .Xaml.cs file code (Notice the converter here):
    using System.Windows;
    using System.Windows.Data;
    
        namespace GridTest
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                }
            }
        
            public class FourWidthConverter : IValueConverter
            {
                public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    return 4 * (double)value;
                }
        
                public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new System.NotImplementedException();
                }
            }
        }
