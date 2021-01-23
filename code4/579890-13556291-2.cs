    namespace StackOverflow.ListUnit
    {
        using AutoMapper;
        public class MyProfile : Profile
        {
            public override string ProfileName
            {
                get
                {
                    return "MyProfile";
                }
            }
            protected override void Configure()
            {
                Mapper.CreateMap<Unit, UnitTreeViewModel>();
            }
        }
    }
