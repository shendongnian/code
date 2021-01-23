	void Button_Click(object sender, EventArgs e)
	{
		int age;
		if (!int.TryParse(ageTextBox.Text, out age))
		{
			DisplayError("Invalid age entered");
		}
		if (age < 0)
		{
			DisplayError("age must be positive");
		}
		if (age >= 1000)
		{
			DisplayError("age must be less than 1000");
		}
		
		DoSomething();
	}
