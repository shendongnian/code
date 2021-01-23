    public class MyMultiConverter: IMultiValueConverter
    {
        public object Convert(object[] values, ...)
        {
            return values.Clone();
        }
    }
