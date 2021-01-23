	public class Candidate : DependencyObject
	{
		//CandidateID Dependency Property
		public int CandidateID
		{
			get { return (int)GetValue(CandidateIDProperty); }
			set { SetValue(CandidateIDProperty, value); }
		}
		public static readonly DependencyProperty CandidateIDProperty =
			DependencyProperty.Register("CandidateID", typeof(int), typeof(Candidate), new UIPropertyMetadata(0));
		//RegisterNo Dependency Property
		public int RegisterNo
		{
			get { return (int)GetValue(RegisterNoProperty); }
			set { SetValue(RegisterNoProperty, value); }
		}
		public static readonly DependencyProperty RegisterNoProperty =
			DependencyProperty.Register("RegisterNo", typeof(int), typeof(Candidate), new UIPropertyMetadata(0));
		//CandidateName Dependency Property
		public string CandidateName
		{
			get { return (string)GetValue(CandidateNameProperty); }
			set { SetValue(CandidateNameProperty, value); }
		}
		public static readonly DependencyProperty CandidateNameProperty =
			DependencyProperty.Register("CandidateName", typeof(string), typeof(Candidate), new UIPropertyMetadata(""));
		//BooleanFlag Dependency Property
		public bool BooleanFlag
		{
			get { return (bool)GetValue(BooleanFlagProperty); }
			set { SetValue(BooleanFlagProperty, value); }
		}
		public static readonly DependencyProperty BooleanFlagProperty =
			DependencyProperty.Register("BooleanFlag", typeof(bool), typeof(Candidate), new UIPropertyMetadata(false));
	}
