    [Serializable]
    public class MyClass
    {
        [JsonConverter(typeof(CustomBitmapConverter))]
        public Bitmap MyImage { get; set; }
      
        #region JsonConverterBitmap
        internal class CustomBitmapConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
