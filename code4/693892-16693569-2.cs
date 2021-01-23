        jsonWriter.WriteStartArray(); // Starts Json Array notation;
        
        while (reader.Read())
        {
            int fieldcount = reader.FieldCount; // count how many columns are in the row
            object[] values = new object[fieldcount]; // storage for column values
            reader.GetValues(values); // extract the values in each column
            jsonWriter.WriteStartObject();
            for (int index = 0; index < fieldcount; index++)
            { // iterate through all columns
                jsonWriter.WritePropertyName(reader.GetName(index)); // column name
                jsonWriter.WriteValue(values[index]); // value in column
            }
            jsonWriter.WriteEndObject();
        }
        reader.Close();
        
        jsonWriter.WriteEndArray();  // Ends Json Array notation;
