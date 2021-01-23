       while (reader.Read())
        {
            var myObj = new MyType()
            {
                MyNumberValue = reader.GetInt32(0),
                MyStringValue = reader.GetString(1)
            };
            var optValue = default(string);
            reader.TryGetValue("optColName", out optValue);
            myObj.OptionalString = optValue;
        }
