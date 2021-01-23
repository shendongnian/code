		public MainWindow()
		{
			DataContext = this;
			CandidateList.Add(new Candidate()
			{
				CandidateID = 1,
				CandidateName = "Jack",
				RegisterNo = 123,
				BooleanFlag = true
			});
			CandidateList.Add(new Candidate()
			{
				CandidateID = 2,
				CandidateName = "Jim",
				RegisterNo = 234,
				BooleanFlag = false
			});
			InitializeComponent();
		}
		//List Observable Collection
		private ObservableCollection<Candidate> _candidateList = new ObservableCollection<Candidate>();
		public ObservableCollection<Candidate> CandidateList { get { return _candidateList; } }
		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			foreach (var item in CandidateList)
			{
				item.BooleanFlag = true;
			}
		}
		private void UnheckBox_Checked(object sender, RoutedEventArgs e)
		{
			foreach (var item in CandidateList)
			{
				item.BooleanFlag = false;
			}
		}
