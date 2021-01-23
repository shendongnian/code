	void DoSomething()
	{
		int age = int.Parse(ageTextBox.Text);
		if (age < 0)
		{
			throw new ArgumentOutOfRangeException("age must be positive");
		}
		if (age >= 1000)
		{
			throw new ArgumentOutOfRangeException("age must be less than 1000");
		}
	}
	
	void Button_Click(object sender, EventArgs e)
	{
		try
		{
			DoSomething();
		}
		catch (Exception ex)
		{
			DisplayError(ex.Message);
		}
	}
	
