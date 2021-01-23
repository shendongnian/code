    CreateMap<StagingPerson, Person>()
      .ForMember( dest => dest.SexString, u => u.MapFrom( src => src.Sex) )
      .ForMember( dest => dest.SEXID, u.Ignore() ) );
    /// The source class
    public class StagingPerson
    {
      /// holds "M", "F", "U", "?", etc
      public string Gender {get;set;}
    }
