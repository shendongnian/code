	public class StudentViewModel : DependencyObject
	{
		// Parameterless constructor
		public StudentViewModel()
		{
		}
		// StudentType Dependency Property
		public string StudentType
		{
			get { return (string)GetValue(StudentTypeProperty); }
			set { SetValue(StudentTypeProperty, value); }
		}
		public static readonly DependencyProperty StudentTypeProperty =
			DependencyProperty.Register("StudentType", typeof(string), typeof(StudentViewModel), new PropertyMetadata("DefaultType", StudentTypeChanged));
		// When type changes then populate students
		private static void StudentTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var studentVm = d as StudentViewModel;
			if (d == null) return;
			studentVm.PopulateStudents();
		}
		public void PopulateStudents()
		{
			// Do stuff
		}
		// Other class stuff...
	}
