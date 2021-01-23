    public class ExampleProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonView>()
                .ForMember(personView => personView.Name, person => person.ResolveUsing<PersonNameResolver>());
        }
    }
