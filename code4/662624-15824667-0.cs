	private void detailsButton_Click(object sender, EventArgs e)
	{
		if (peopleListBox.SelectedItem == null)
		{
			MessageBox.Show("No person selected!");
		}
		else
		{
			PersonDetails personDetails = 
                            new PersonDetails(peopleListBox.SelectedItem);
			personDetails.Show();
		}
	}
