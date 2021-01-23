    public static class DataReaderExtension
    {
        public static void ToCsv(this IDataReader dataReader, string fileName, bool includeHeaderAsFirstRow)
        {
            const string Separator = ",";
            StreamWriter streamWriter = new StreamWriter(fileName);
            StringBuilder sb = null;
            if (includeHeaderAsFirstRow)
            {
                sb = new StringBuilder();
                for (int index = 0; index < dataReader.FieldCount; index++)
                {
                    if (dataReader.GetName(index) != null)
                        sb.Append(dataReader.GetName(index));
                    if (index < dataReader.FieldCount - 1)
                        sb.Append(Separator);
                }
                streamWriter.WriteLine(sb.ToString());
            }
            while (dataReader.Read())
            {
                sb = new StringBuilder();
                for (int index = 0; index < dataReader.FieldCount - 1; index++)
                {
                    if (!dataReader.IsDBNull(index))
                    {
                        string value = dataReader.GetValue(index).ToString();
                        if (dataReader.GetFieldType(index) == typeof(String))
                        {
                            if (value.IndexOf("\"") >= 0)
                                value = value.Replace("\"", "\"\"");
                            if (value.IndexOf(Separator) >= 0)
                                value = "\"" + value + "\"";
                        }
                        sb.Append(value);
                    }
                    if (index < dataReader.FieldCount - 1)
                        sb.Append(Separator);
                }
                if (!dataReader.IsDBNull(dataReader.FieldCount - 1))
                    sb.Append(dataReader.GetValue(dataReader.FieldCount - 1).ToString().Replace(Separator, " "));
                streamWriter.WriteLine(sb.ToString());
            }
            dataReader.Close();
            streamWriter.Close();
        }
    }
