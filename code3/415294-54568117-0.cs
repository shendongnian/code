<UserControl x:Class="Infra.UICommon.Controls.TimeControl"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:Infra.UICommon.Controls"
             mc:Ignorable="d" 
             Height="Auto" Width="Auto" x:Name="UserControl" 
             d:DesignHeight="300" d:DesignWidth="300">
    <Grid x:Name="LayoutRoot" Width="Auto" Height="Auto" Background="White">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="0.2*"/>
            <ColumnDefinition Width="0.05*"/>
            <ColumnDefinition Width="0.2*"/>
            <ColumnDefinition Width="0.05*"/>
            <ColumnDefinition Width="0.2*"/>
            <ColumnDefinition Width="0.05*"/>
            <ColumnDefinition Width="0.2*"/>
        </Grid.ColumnDefinitions>
        <!-- Hours -->
        <Grid x:Name="hours" Focusable="True" MouseWheel="OnMouseWheel" >
            <TextBox x:Name="hh" TextWrapping="Wrap" Text="{Binding Path=Hours, ElementName=UserControl, Mode=Default}" PreviewKeyDown="OnKeyDown"
                 TextAlignment="Center" VerticalAlignment="Center"  BorderThickness="0"/>
        </Grid>
        <!-- Separator ':' -->
        <Grid  Grid.Column="1">
            <TextBox IsReadOnly="True" x:Name="sep1" TextWrapping="Wrap" VerticalAlignment="Center" Text=":" TextAlignment="Center"  BorderThickness="0"/>
        </Grid>
        <!-- Minutes -->
        <Grid  Grid.Column="2" x:Name="minutes" Focusable="True" MouseWheel="OnMouseWheel">
            <TextBox  x:Name="mm"  TextWrapping="Wrap" Text="{Binding Path=Minutes, ElementName=UserControl, Mode=Default}" PreviewKeyDown="OnKeyDown"
                  TextAlignment="Center" VerticalAlignment="Center" BorderThickness="0" />
        </Grid>
        <!-- Separator ':' -->
        <Grid  Grid.Column="3">
            <TextBox IsReadOnly="True" x:Name="sep2"  TextWrapping="Wrap" VerticalAlignment="Center" Text=":" TextAlignment="Center"  BorderThickness="0"/>
        </Grid>
        <!-- Seconds -->
        <Grid  Grid.Column="4" Name="seconds" Focusable="True" MouseWheel="OnMouseWheel">
            <TextBox x:Name="ss"  TextWrapping="Wrap" Text="{Binding Path=Seconds, ElementName=UserControl, Mode=Default}" PreviewKeyDown="OnKeyDown"
                 TextAlignment="Center" VerticalAlignment="Center" BorderThickness="0" />
        </Grid>
        <!-- Separator ':' -->
        <Grid  Grid.Column="5">
            <TextBox IsReadOnly="True" x:Name="sep3"  TextWrapping="Wrap" VerticalAlignment="Center"  Text=":" TextAlignment="Center"  BorderThickness="0"/>
        </Grid>
        <!-- Milliseconds -->
        <Grid  Grid.Column="6" Name="miliseconds" Focusable="True" MouseWheel="OnMouseWheel">
            <TextBox x:Name="ff"  TextWrapping="Wrap" Text="{Binding Path=Milliseconds, ElementName=UserControl, Mode=Default}" PreviewKeyDown="OnKeyDown"
                 TextAlignment="Center" VerticalAlignment="Center" BorderThickness="0" />
        </Grid>
    </Grid>
</UserControl>
TimeControl.xaml.cs (code behind)
namespace Infra.UICommon.Controls
{
    /// <summary>
    /// Interaction logic for TimeControl.xaml
    /// </summary>
    public partial class TimeControl : UserControl
    {
        public TimeControl()
        {
            InitializeComponent();
        }
        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimeControl control = obj as TimeControl;
            var newTime = (TimeSpan)e.NewValue;
            control.Hours        = newTime.Hours;
            control.Minutes      = newTime.Minutes;
            control.Seconds      = newTime.Seconds;
            control.Milliseconds = newTime.Milliseconds;
        }
        private static void OnTimeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TimeControl control = obj as TimeControl;
            control.Value = new TimeSpan(0, control.Hours, control.Minutes, control.Seconds, control.Milliseconds);
        }
        public TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(TimeSpan), typeof(TimeControl),
        new FrameworkPropertyMetadata(DateTime.Now.TimeOfDay, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnValueChanged)));
        public int Hours
        {
            get { return (int)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }
        public static readonly DependencyProperty HoursProperty =
        DependencyProperty.Register("Hours", typeof(int), typeof(TimeControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
        public int Minutes
        {
            get { return (int)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }
        public static readonly DependencyProperty MinutesProperty =
        DependencyProperty.Register("Minutes", typeof(int), typeof(TimeControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
        public int Seconds
        {
            get { return (int)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }
        public static readonly DependencyProperty SecondsProperty =
        DependencyProperty.Register("Seconds", typeof(int), typeof(TimeControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
        public int Milliseconds
        {
            get { return (int)GetValue(MillisecondsProperty); }
            set { SetValue(MillisecondsProperty, value); }
        }
        public static readonly DependencyProperty MillisecondsProperty =
        DependencyProperty.Register("Milliseconds", typeof(int), typeof(TimeControl),
        new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnTimeChanged)));
        private Tuple<int, int> GetMaxAndCurentValues(String name)
        {
            int maxValue = 0;
            int currValue = 0;
            switch (name)
            {
                case "ff":
                    maxValue = 1000;
                    currValue = Milliseconds; 
                    break;
                case "ss":
                    maxValue = 60;
                    currValue = Seconds;
                    break;
                case "mm":
                    maxValue = 60;
                    currValue = Minutes;
                    break;
                case "hh":
                    maxValue = 24;
                    currValue = Hours;
                    break;
            }
            return new Tuple<int, int>(maxValue, currValue);
        }
        private void UpdateTimeValue(String name, int delta)
        {
            var values = GetMaxAndCurentValues(name);
            int maxValue = values.Item1;
            int currValue = values.Item2;
            // Set new value
            int newValue = currValue + delta;
            if (newValue == maxValue)
            {
                newValue = 0;
            }
            else if (newValue < 0)
            {
                newValue += maxValue;
            }
            switch (name)
            {
                case "ff":
                    Milliseconds = newValue;
                    break;
                case "ss":
                    Seconds = newValue;
                    break;
                case "mm":
                    Minutes = newValue;
                    break;
                case "hh":
                    Hours = newValue;
                    break;
            }
        }
        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            try
            {
                int delta = 0;
                String name = ((TextBox)sender).Name;
                if (args.Key == Key.Up) { delta = 1; }
                else if (args.Key == Key.Down) { delta = -1; }
                UpdateTimeValue(name, delta);
            }
            catch { }
        }
        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                var g = (Grid)(sender);
                var value = g.Children.OfType<TextBox>().FirstOrDefault();
                UpdateTimeValue(value.Name, e.Delta / Math.Abs(e.Delta));
            }
            catch { }
        }
    }
}
Usage: 
<ctrl:TimeControl Value="{Binding StartTime, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" x:Name="startTime"/>
Where 'ctrl' is the namespace where the TimeControl is located, and 'StartTime' is a  property of the type 'TimeSpan'. 
xmlns:ctrl="clr-namespace:Infra.UICommon.Controls;assembly=Infra.UICommon"
Hope this helps)
