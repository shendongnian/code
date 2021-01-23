    JsonConvert.SerializeObject(graph,Formatting.None, new JsonSerializerSettings()
                                                                                                   {
                                                                                                     TypeNameHandling = TypeNameHandling.All,
                                                                                                   TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                                                                                               });
