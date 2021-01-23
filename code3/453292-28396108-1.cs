    public class ContactMappingProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Contact, ContactDTO>();
            this.CreateMap<ContactDTO, Contact>();
        }
    }
