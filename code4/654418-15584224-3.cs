    Mapper.CreateMap<RegistrationDTO, Registration>()
       .ForMember(d => d.id, o => o.Ignore())
       .ForMember(d => d.CreatedAt, o => o.UseValue(DateTime.Now))
       .ForMember(d => d.Departments, o => o.MapFrom(s => 
       {
           var dbContext = new MyDbContext();
           var departments = new List<int>(s.Departments)
               .ConvertAll(input => dbContext.Departments.Find(input));
           return departments;
       }))
    ;
