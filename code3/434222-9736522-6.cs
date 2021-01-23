    ConvertApi FindMatchingConverter(string _FileExt)
            {
                //Get all the converters available.
                List<ConvertApi> converters = this.GetType()
                                               .Assembly
                                               .GetExportedTypes()
                                               .Where(type => type.IsAssignableFrom(typeof(ConvertApi)))
                                               .ToList();
    
                //Loop and find which converter to use
                foreach (var converter in converters)
                {
                    if (converter.SupportedFiles.Contains(_FileExt))
                        return Activator.CreateInstance(converter);
                }
                throw new Exception("No converter found");
            }
