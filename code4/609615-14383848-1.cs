    public class ThemeWindow : Window
    {
        static ThemeWindow()
        {
            StyleProperty.OverrideMetadata(typeof(ThemeWindow), new FrameworkPropertyMetadata(GetDefautlStyle()));
        }
        private static Style GetDefautlStyle()
        {
            if (defaultStyle == null)
            {
                defaultStyle = Application.Current.FindResource(typeof(ThemeWindow)) as Style;
            }
            return defaultStyle;
        }
        private static Style defaultStyle = null;
    }
