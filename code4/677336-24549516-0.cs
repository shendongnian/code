    using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    string[] colFields = csvReader.ReadFields();
                  
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        for (i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                            else
                            {
                                if (fieldData[i][0] == '"' && fieldData[i][fieldData[i].Length - 1] == '"')
                                {
                                    fieldData[i] = fieldData[i].Substring(1, fieldData[i].Length - 2);
                                }
                            }
                        }
                        csvData.Rows.Add(fieldData);
                       }
                }
