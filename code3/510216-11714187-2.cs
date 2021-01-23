    <!-- ToolBar.xaml -->
    <UserControl ...
                 Name="control">
        <!-- ... -->
        <Slider Value="{Binding ScaleValue, ElementName=control}" ... />
        <!-- ... -->
    </UserControl>
<!---->
    // ToolBar.xaml.cs
    public partial class ToolBar : UserControl
    {
        public static readonly DependencyProperty ScaleValueProperty =
            DependencyProperty.Register("ScaleValue", typeof(double), typeof(ToolBar));
        public double ScaleValue
        {
            { get { return (double)GetValue(ScaleValueProperty); }
            { set { SetValue(ScaleValueProperty, value); }
        }
    }
