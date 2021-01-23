    Mapper.CreateMap<Client, ClientGrid>()
        .ConvertUsing<ClientToClientGridConverter>();
    class ClientToClientGridConverter
        : AutoMapper.ITypeConverter<Client, ClientGrid>
    {
        public ClientGrid Convert(AutoMapper.ResolutionContext context)
        {
            if (context == null || context.IsSourceValueNull) 
            { 
                return null;
            }
            var client = context.SourceValue as Client;
            var clientGrid = new ClientGrid();
            // conversion rules and logic here
            return clientGrid 
        }
    }
