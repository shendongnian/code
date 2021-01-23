        public string ValidateUnmappedConfiguration(IMapper mapper)
        {
            try
            {
                mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException e)
            {
                  return e.Message;
            }
            return "";
        }
