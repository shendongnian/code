    public class MyProfile : Profile
    {
        public override string ProfileName
        {
            get { return "Name"; }
        }
        protected override void Configure()
        {
            //// BL to DL
            Mapper.CreateMap<BLCLASS, DLCLASS>();
            ////  and DL to BL
            Mapper.CreateMap<DLCLASS, BLCLASS>();
        }
    }
