    private class JsonTextWriterOptimized : JsonTextWriter
    {
		public JsonTextWriterOptimized(TextWriter textWriter)
			: base(textWriter)
		{
		}
		public override void WriteValue(decimal value)
		{
			value = Math.Round(value, 4);
			base.WriteValue(value);
		}
	}
