	public static class StudyExtensions
	{
		public static IQueryable<study> AllDeleted(this IQueryable<study> studies)
		{
			return studies.Where(study => !study.series.Any(series => !series.deleted));
		}
	}
	class Program
	{
		public static void Main()
		{
			DBDataContext db = new DBDataContext();
			db.Log = Console.Out;
			var deletedStudies = 
				from study in db.studies.AllDeleted()
				select study;
			foreach (var study in deletedStudies)
			{
				Console.WriteLine(study.name);
			}
		}
	}
