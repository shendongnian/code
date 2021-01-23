        public class CountryModelConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                if (objectType == typeof(CountryModel))
                {
                    return true;
                }
                return false;
            }
            public override object ReadJson(JsonReader reader, Type objectType
                , object existingValue, JsonSerializer serializer)
            {
                reader.Read(); //start array
                //reader.Read(); //start object
                JObject obj = (JObject)serializer.Deserialize(reader);
                //{"page":1,"pages":1,"per_page":"50","total":35}
                var model = new CountryModel();
                model.Page = Convert.ToInt32(((JValue)obj["page"]).Value);
                model.Pages = Convert.ToInt32(((JValue)obj["pages"]).Value);
                model.Per_Page = Int32.Parse((string) ((JValue)obj["per_page"]).Value);
                model.Total = Convert.ToInt32(((JValue)obj["total"]).Value);
                reader.Read(); //end object
                model.Countries = serializer.Deserialize<List<Country>>(reader);
                reader.Read(); //end array
                return model;
            }
            public override void WriteJson(JsonWriter writer, object value
                , JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
