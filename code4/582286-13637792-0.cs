    namespace StackOverflow.Function
    {
        using AutoMapper;
        public class MyProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<Function, FunctionDto>();
            }
        }
    }
