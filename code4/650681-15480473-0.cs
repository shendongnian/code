    public class AccountProfile : Profile
    {
        protected override void Configure()
        {
            // Map from Entity object to a View Model we need or use
            // AutoMapper will automatically map any names that match it's conventions, ie properties from Entity to ViewModel have exact same name properties
            
            Mapper.CreateMap<Account, AccountViewModel>()
                  .ForMember(model => model.CurrentPrivacy, opt => opt.MapFrom(account => (PrivacyLevelViewModel)account.PrivacyLevel));
            Mapper.CreateMap<Account, EditAccountViewModel>()
                .ForMember(model => model.SelectedPrivacyLevel, opt => opt.MapFrom(account => (PrivacyLevelViewModel) account.PrivacyLevel));
            // From our View Model Changes back to our entity
            Mapper.CreateMap<EditAccountViewModel, Account>()
                  .ForMember(entity => entity.Id, opt => opt.Ignore()) // We dont change id's
                  .ForMember(entity => entity.PrivacyLevel, opt => opt.MapFrom(viewModel => (PrivacyLevel)viewModel.NewSelectedPrivacyLevel));
        }
        
    }
