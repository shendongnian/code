    public class RadiusConverter : IValueConverter
    {
        public object Convert(object value, /*snip*/)
        {
            // check null, type, and double.NaN here
            return (double)value * 2;
        }
        /* snip, on the round trip same as before but / 2 */
    }
