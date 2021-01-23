	public Form1()
	{
		InitializeComponent();
		
		// I set tabPage1 & 2 event w/ the designer
		tabPage3.Enter += tabPage3_Enter;
	}
	private void tabPage1_Enter(object sender, EventArgs e)
	{
		Debug.WriteLine("tabPage1_Enter");
	}
	private void tabPage2_Enter(object sender, EventArgs e)
	{
		Debug.WriteLine("tabPage2_Enter");
	}
	private void tabPage3_Enter(object sender, EventArgs e)
	{
		Debug.WriteLine("tabPage3_Enter");
	}
