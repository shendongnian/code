    public class CreateMaps
    {
       public void CreateAllMaps()
       {
          Mapper.CreateMap<InnerSource, InnerClass>();
          Mapper.CreateMap<OuterSource, OuterClass>();
       }
    }
