    public class GameStateConverter
        : MvxBaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("gamestates/{0}.png", (GameState)value);
        }
    }
