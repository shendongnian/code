    <UserControl ...
                 Name="control">
        <!-- ... -->
        <Slider Value="{Binding ScaleValue, ElementName=control}" ... />
        <!-- ... -->
    </UserControl>
<!---->
    public class ToolBar : UserControl
    {
        public static readonly DependencyProperty ScaleValue =
            DependencyProperty.Register("ScaleValue", ...);
    }
