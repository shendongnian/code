    public MeetingOverview()
        {
            theMeeting = (Meeting)App.meetings.ElementAt(App.selectedMeetingIndex);
            meetingX = theMeeting.MeetingName.ToString();
            this.DataContext = this;
            InitializeComponent();        
        }
