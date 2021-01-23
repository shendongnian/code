    [TypeConverter(typeof(CustomColorTypeConverter))]
    public class CustomColor
    {
        public static CustomColor Stop = new CustomColor { Color = Color.Red };
        public static CustomColor Go = new CustomColor { Color = Color.Green };
        public static CustomColor Yield = new CustomColor { Color = Color.Yellow };
        public Color Color { get; private set; }
        internal static CustomColor Find(Color color)
        {
            if (color == CustomColor.Stop.Color)
                return CustomColor.Stop;
            else if (color == CustomColor.Go.Color)
                return CustomColor.Go;
            else if (color == CustomColor.Yield.Color)
                return CustomColor.Yield;
            return new CustomColor { Color = Color.Transparent };
        }
    }
