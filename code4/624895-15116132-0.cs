                foreach (DataRow row in table.Rows)
                {
                    jsonWriter.WriteStartObject();
                    foreach (DataColumn col in table.Columns)
                    {
                        jsonWriter.WritePropertyName(col.ColumnName);
                        jsonWriter.WriteValue((row[col.ColumnName] == null) ? string.Empty : row[col.ColumnName].ToString());
                    }
                    jsonWriter.WriteEndObject();
                }
