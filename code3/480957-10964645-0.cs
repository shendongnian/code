	public class StudentViewModel: PropertyChangedBase
	{
		public StudentModel Student { get; set; }
		public void SaveStudent()
		{
			MessageBox.Show(String.Format("Saved: {0} - ({1})", Student.FirstName, Student.GradePoint));
		}
		public StudentViewModel()
		{
			Student = new StudentModel { FirstName = "Tom Johnson", GradePoint = 3.7 };
			Student.PropertyChanged += delegate { NotifyOfPropertyChanged( () => CanSaveStudent)};
		}
		private Boolean CanSaveStudent
		{
			get 
			{
				return Student.GradePoint >= 0.0 || Student.GradePoint <= 4.0;
			}
		}
	}
