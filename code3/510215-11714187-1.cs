    <UserControl ...
                 Name="control">
        <!-- ... -->
        <Slider Value="{Binding ScaleValue, ElementName=control}" ... />
        <!-- ... -->
    </UserControl>
<!---->
    public partial class ToolBar : UserControl
    {
        public static readonly DependencyProperty ScaleValue =
            DependencyProperty.Register("ScaleValue", ...);
    }
