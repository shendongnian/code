        private PersistantHelper persistantHelper;
        public frmTester()
        {
            InitializeComponent();
            this.persistantHelper = new PersistantHelper();
            .
            .
            .
        }
	private void LoadPersistantData()
	{
		State state = this.persistantHelper.State;
		this.txtPattern.Text = state.Pattern;
		this.txtTest.Text = state.TestString;
		foreach (Control c in this.pnlOptions.Controls)
		{
			if (c is CheckBox)
			{
				var chk = c as CheckBox;
				int tag = int.Parse(c.Tag.ToString());
				chk.Checked = (state.Options & tag) == tag;
			}
		}
	}
	
	
	private void SavePersistantData()
	{
		this.persistantHelper.State = new State()
		{
			Options = (int)this.GetOptions(),
			Pattern = txtPattern.Text,
			TestString = txtTest.Text
		};
	}		
