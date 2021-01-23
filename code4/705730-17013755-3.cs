    class ChartDataRecordCollectionConverter : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var set = (ChartDataRecordCollection) value;
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            writer.WriteStartArray();
            //Group up the records in the collection by the 'date' property
            foreach (var record in set.GroupBy(x => x.date))
            {
                writer.WriteStartObject();
                writer.WritePropertyName("date");
                writer.WriteValue(record.Key);
                //Write the graph/value pairs as properties and values
                foreach (var part in record)
                {
                    writer.WritePropertyName(part.graph);
                    writer.WriteValue(part.value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new ChartDataRecordCollection();
            var obj = JObject.Load(reader);
            var container = obj["data"];
            //Examine each object in the array of values from the result
            foreach (JObject item in container)
            {
                //Get and store the date property
                var date = item["date"].Value<long>();
                //For each property that is not the date property on the object, construct a
                //  ChartDataRecord with the appropriate graph/value pair
                foreach (var property in item.Properties())
                {
                    if (property.Name == "date")
                    {
                        continue;
                    }
                    result.Add(new ChartDataRecord
                    {
                        date = date,
                        graph = property.Name,
                        value = item[property.Name].Value<int>()
                    });
                }
            }
            return result;
        }
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (ChartDataRecordCollection);
        }
    }
