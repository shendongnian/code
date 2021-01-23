    public class TupleKeyConverter : JsonConverter
    {
        /// <summary>
        /// Override ReadJson to read the dictionary key and value
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Tuple<string, string> _tuple = null;
            string _value = null;
            Dictionary<Tuple<string, string>, string> _dict = new Dictionary<Tuple<string, string>, string>();
    
            //loop through the JSON string reader
            while (reader.Read())
            {
                // check whether it is a property
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    string readerValue = reader.Value.ToString();
                    if (reader.Read())
                    {
                        // check if the property is tuple (Dictionary key)
                        if (readerValue.Contains('(') && readerValue.Contains(')'))
                        {
                            string[] result = ConvertTuple(readerValue);
    
                            if (result == null)
                                continue;
    
                            // Custom Deserialize the Dictionary key (Tuple)
                            _tuple = Tuple.Create<string, string>(result[0].Trim(), result[1].Trim());
    
                            // Custom Deserialize the Dictionary value
                            _value = (string)serializer.Deserialize(reader, _value.GetType());
    
                            _dict.Add(_tuple, _value);
                        }
                        else
                        {
                            // Deserialize the remaining data from the reader
                            serializer.Deserialize(reader);
                            break;
                        }
                    }
                }
            }
            return _dict;
        }
    
        /// <summary>
        /// To convert Tuple
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
        public string[] ConvertTuple(string _string)
        {
            string tempStr = null;
    
            // remove the first character which is a brace '('
            if (_string.Contains('(') == true)
                tempStr = _string.Remove(0, 1);
    
            // remove the last character which is a brace ')'
            if (_string.Contains(')') == true)
                tempStr = tempStr.Remove(tempStr.Length - 1, 1);
    
            // seperate the Item1 and Item2
            if (_string.Contains(',') == true)
                return tempStr.Split(',');
    
            return null;
        }
    
        /// <summary>
        /// WriteJson needs to be implemented since it is an abstract function.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    
        /// <summary>
        /// Check whether to convert or not
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
