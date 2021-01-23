    private class JsonTextWriterOptimized : JsonTextWriter
    {
        public JsonTextWriterOptimized(TextWriter textWriter)
            : base(textWriter)
        {
        }
        public override void WriteValue(decimal value)
        {
            // we really really really want the value to be serialized as "0.0000" not "0.00" or "0.0000"!
            value = Math.Round(value, 4);
            // divide first to force the appearance of 4 decimals
            value = Math.Round((((value+0.00001M)/10000)*10000)-0.00001M, 4); 
            base.WriteValue(value);
        }
    }
