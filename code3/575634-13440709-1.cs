	int valueOF1 = 0;
	int valueOF2 = 0;
	private void b_calculate_Click(object sender, EventArgs e)
	{
		int.TryParse(t_Offset1.Text, NumberStyles.Any,
					 CultureInfo.InvariantCulture.NumberFormat, out valueOF1);
		
		int.TryParse(t_Offset2.Text, NumberStyles.Any,
					 CultureInfo.InvariantCulture.NumberFormat, out valueOF2);
		int pRows = PrimaryRadGridView.Rows.Count;
		int sRows = SecondaryRadGridView.Rows.Count;
		if (pRows == 1 && sRows == 1)
		{
			calculatePS(valueOF1, valueOF2);
		}
	}
	private void calculatePS(int valueOF1, int valueOF2)
	{
		// ** you can use valueOF1 and valueOF2 here **
	
		MessageBox.Show("You are using : P-S");
		// Do some calculation & go to the next function ///
		Button2.Enabled = true;
		//probably no need to register the Button2.Click event handler
		//except when the form is created
		//
		//Button2.Click += testfunction; // Here i want to pass the valueOF1 & valueOF2
	}
	public void testfunction(object sender, EventArgs ea)
	{
		// ** you can use valueOF1 and valueOF2 here as well **
	
		MessageBox.Show("you...!");
		Button2.Enabled = false;
	}
