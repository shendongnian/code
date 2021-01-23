    class JsonNetFormatter : MediaTypeFormatter {
        public override bool CanWriteType(Type t) {
            return typeof(JsonNetResponse).IsAssignableFrom(t);
        }
        // TODO WriteToStreamAsync which is basically a copy of your original JsonNetResult
    }
