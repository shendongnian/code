    public Student[] GetStudents()
    {
        try
        { // Suspend/Ignore the mappings
            // => SUSPEND CONFIGURATION MAPPINGS for Subjects, Activities and Clubs
            Mapper.CreateMap<TableStudent, Student>()
                        .ForMember(dest => dest.Courses, opt => opt.Ignore())
                        .ForMember(dest => dest.Activities, opt => opt.Ignore())
                        .ForMember(dest => dest.Clubs, opt => opt.Ignore())
            DataContext dbContext = new StudentDBContext();
            var query = dbContext.Students;
    	
            // other logic ...
            var students = Mapper.Map<Student>(query); // => Still be able to use AutoMapper to map other members
            // set the properties you needed to do manually
        }
        finally // Restore back the mappings
        {
            Mapper.CreateMap<TableStudent, Student>()
                        .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Course>>(src.TableCourses)))
                        .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Activity>>(src.TableActivities)))
                        .ForMember(dest => dest.Clubs, opt => opt.MapFrom(src => Mapper.Map<IEnumerable<Clubs>>(src.TableClubs)))
        }
    }
