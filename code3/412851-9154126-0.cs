                        using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                        {
                            jsonWriter.Formatting = Formatting.Indented;
                            jsonWriter.WriteStartObject();
                            jsonWriter.WriteProperty("label:", servicename);
                            jsonWriter.WritePropertyName("data:");
                            jsonWriter.WriteStartArray();
                            for (int i = 0; i < 1; i++)
                            {
                                jsonWriter.WriteValue(currentcount + ", " + currentrating);
                            }
                            jsonWriter.WriteEnd();
                            jsonWriter.WriteEndObject();
                        }
