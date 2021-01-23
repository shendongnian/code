    public SpeechStateEnumeration SpeechState { get; set; }
		
    public Window1()
    {
    	InitializeComponent();
    	SpeechState = SpeechStateEnumeration.Listening;
    	DataContext = this;
    }
