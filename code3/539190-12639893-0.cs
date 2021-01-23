      public class ContainerAToContainerB : Profile
        {
            protected override void Configure()
            {
                CreateMap<ContainerA, ContainerB>()
                    .ForMember(dest => dest.ClassBList,opt=>opt.MapFrom(src=>src.ClassAList))
                    .ForMember(dest => dest.ClassB, opt => opt.MapFrom(src => src.ClassA));
    
            }
    }
