	class StudentComparer : IComparer<Student>
	{
		public int Compare(Student a, Student b)
		{
			return a.Name.CompareTo(b.Name);
		}
	}
