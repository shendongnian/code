    protected void Application_Start()
    {
        Mapper.CreateMap<Person, PersonDto>();
    }
    ...
    // public API method
    public PersonDto GetPersonApi(int id)
    {
        var personEntity = // pull entity from db
        return Mapper.Map<Person, PersonDto>(personEntity);
    }
    
