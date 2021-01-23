    public class JsonFormatter : MediaTypeFormatter
    {
        private const string WesternEuropeStandardTime = "W. Europe Standard Time";
        private TimeZoneInfo timeZoneInfo;
        public JsonFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            this.timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(WesternEuropeStandardTime);
        }
        public override bool CanReadType(Type type)
        {
            return true;
        }
        public override bool CanWriteType(Type type)
        {
            return true;
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            Task<object> task = Task<object>.Factory.StartNew(() =>
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                StreamReader sr = new StreamReader(readStream);
                JsonTextReader jreader = new JsonTextReader(sr);
                JsonSerializer ser = new JsonSerializer();
                ser.Converters.Add(new DateTimeConverter(this.timeZoneInfo) { DateTimeFormat = "o" });
                return ser.Deserialize(jreader, type);
            });
            return task;
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };
                string json = JsonConvert.SerializeObject(
                    value, 
                    Formatting.Indented,
                    new JsonConverter[1] { new DateTimeConverter(this.timeZoneInfo) { DateTimeFormat = "o" } });
                byte[] buf = System.Text.Encoding.Default.GetBytes(json);
                writeStream.Write(buf, 0, buf.Length);
                writeStream.Flush();
            });
            return task;
        }
        private class DateTimeConverter : IsoDateTimeConverter
        {
            private TimeZoneInfo timeZoneInfo;
            public DateTimeConverter(TimeZoneInfo timeZoneInfo)
            {
                this.timeZoneInfo = timeZoneInfo;
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                DateTime? date = value as DateTime?;
                if (date.HasValue && DateTime.MinValue != date.Value && DateTime.MaxValue != date.Value)
                {
                    TimeSpan timeZoneOffset = this.timeZoneInfo.GetUtcOffset(date.Value);
                    value = DateTime.SpecifyKind(date.Value - timeZoneOffset, DateTimeKind.Utc);
                }
                base.WriteJson(writer, value, serializer);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                object result = base.ReadJson(reader, objectType, existingValue, serializer);
                DateTime? date = result as DateTime?;
                if (date.HasValue && DateTime.MinValue != date.Value && DateTime.MaxValue != date.Value)
                {
                    TimeSpan timeZoneOffset = this.timeZoneInfo.GetUtcOffset(date.Value);
                    result = DateTime.SpecifyKind(date.Value + timeZoneOffset, DateTimeKind.Utc);
                }
                return result;
            }
        }
    }
