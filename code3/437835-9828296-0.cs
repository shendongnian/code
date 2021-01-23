		private WorkStatus m_WorkStatus = new WorkStatus();
		public Form1()
		{
			InitializeComponent();
			this.checkBox_WorkDone.DataBindings.Add("Visible", m_WorkStatus, "Done");
		}
		private void btnToggle_Click(object sender, EventArgs e)
		{
			m_WorkStatus.Done = !m_WorkStatus.Done;
		}
