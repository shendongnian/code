    public class Student
	{
		public string Name { get; set; }
		public List<string> CourseIds { get; set; }
	} 
	public class Course
	{
		public string Name { get; set; }
		public string Id { get; set; }
		public int Credit { get; set; }
	}
	public class ViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Course> StudentCourses { get; set; }
		public ObservableCollection<Student> Students { get; set; }
		public Student SelectedComboItem
		{
			get { return selectedComboItem_; }
			set {
				selectedComboItem_ = value;
				StudentCourses.Clear();
				foreach(Course course in courses_)
					if(selectedComboItem_.CourseIds.Contains(course.Id))
						StudentCourses.Add(course);
				PropertyChanged(this, new PropertyChangedEventArgs("SelectedComboItem"))	;
			}
		}
		
		private List<Course> courses_ = new List<Course>();
		private Student selectedComboItem_;
		... // Read DB and build collections
		public event PropertyChangedEventHandler PropertyChanged;
	}
