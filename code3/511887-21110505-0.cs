    JsonConvert.SerializeObject(graph,Formatting.None, new JsonSerializerSettings()
                                                                                                   {
                                                                                                     TypeNameHandling = TypeNameHandling.Objects,
                                                                                                   TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                                                                                               });
