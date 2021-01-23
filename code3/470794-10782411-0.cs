	public class StudentRepository : IStudentRepository
	{
		static class StudentRepository
		{
			// ... other mappings
			Mapper.CreateMap<TableStudent, Student>()
				.ForMember(dest => dest.Courses, opt => opt.Ignore())
				.ForMember(dest => dest.Activities, opt => opt.Ignore())
				.ForMember(dest => dest.Clubs, opt => opt.Ignore())
			// where TableStudents, TableCourses, TableActivities, TableClubs are database entities
			// ... yet more mappings
		}
	}
