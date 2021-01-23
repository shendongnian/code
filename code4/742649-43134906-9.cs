    private Button buttonCheckbox;
	private Button buttonAction;
	private Button buttonCombo;
	private Button buttonText;
    private void OnButtonCheckbox(object sender, EventArgs e)
	{
		this.AddRow("Do you smoke", AnswerType.YesNo);
	}
	private void OnButtonText(object sender, EventArgs e)
	{
		this.AddRow("Name", AnswerType.Text);
	}
	private void OnButtonCombo(object sender, EventArgs e)
	{
		this.AddRow("Age?", AnswerType.Combo);
	}
	private void OnButtonAction(object sender, EventArgs e)
	{
		this.AddRow("Document upload", AnswerType.LoadFile);
	}
