	/// <summary>
	/// Flag which can be accessed by the checkboxes which indicates if the program is making the change or the user is.
	/// </summary>
	bool programmaticallySettingChecks { get; set; }
	protected void FlagExample()
	{
		CheckBox[] chToCheck = new CheckBox[10];		//Collection of checkboxes to set the Checked property on.
		programmaticallySettingChecks = true;
		for (int i = 0; i < chToCheck.Length; i++)
		{
			chToCheck[0].Checked = true;
		}
		programmaticallySettingChecks = false;
	}
	protected void Check_Clicked(Object sender, EventArgs e)
	{
		if (programmaticallySettingChecks)
		{
			//do things which are done if setting programmatically.
		}
		else
		{
			//Do things which are done if user sets.
		}
	}
