	if (chkCar.Items[i].Selected == true)
	{
		Panel tt = new Panel();
		Panel2.Controls.Add(new LiteralControl("<br />"));
		Label mylab = new Label();
		mylab.ID = "mylab" + NextID1;
		mylab.Text = "No of Persons in " + chkCar.Items[i].Value;
		Panel2.Controls.Add(mylab);
		ControlsList1.Add(mylab.ID) // <--- here
		
		TextBox mytext = new TextBox();
		mytext.ID = "mytext" + NextID2;
		mytext.Text = "";
		Panel2.Controls.Add(mytext);
		ControlsList2.Add(mytext.ID) // <--- and here
	}
