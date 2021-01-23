    class MappedObject<S, T> // S = Source, T = Target
    {
        public MappedObject() 
        {
             // Required to auto-create a map between the objects  
             AutoMapper.CreateMap(S, T);
        }
    }
