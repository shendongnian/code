    public class JavascriptSerializerWrapper : IJavascriptSerializerWrapper
    {
        private JavascriptSerializer _serializer = new JavascriptSerializer();
        public JavaScriptSerializer Serialize()
        {
            return _serializer.Serialize();
        }
    }
