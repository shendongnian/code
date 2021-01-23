    public class UserProfile : Profile
    {
        private readonly IRoleRepository _roleRepository;
        public UserProfile(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        protected override void Configure()
        {
            CreateMap<UserCreateViewModel, User>()
                .ForMember(x => x.Roles, o => o.MapFrom(
                    x => x.Roles.Select(id => _roleRepository.GetById(id)).ToList());
        }
    }
