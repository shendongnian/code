    public class JavascriptSerializerWrapper : IJavascriptSerializerWrapper
    {
        public string Serialize(object toSerialize)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(toSerialize);
        }
    }
