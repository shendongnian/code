	private void btnAddNewPerson_Click( object sender, EventArgs e )
	{
		// Create combo boxes
		ComboBox cbCity = new ComboBox();
		ComboBox cbState = new ComboBox();
		// Introduce them to each other
		cbCity.Tag = cbState;
		cbState.Tag = cbCity;
		//  ADD State ComboBox
		cbState.Name = "State" + NumberOfPeople;
		cbState.Enabled = true;
		cbState.DropDownStyle = ComboBoxStyle.DropDownList;
		cbState.SelectedValueChanged += new EventHandler( cbState_SelectedValueChanged );
		panel.Controls.Add( cbState );
		// Populate the states sombo
		PopulateStateCombo( cbState );
		//  ADD City ComboBox
		cbCity.Name = "City" + NumberOfPeople;
		cbCity.DropDownStyle = ComboBoxStyle.DropDownList;
		cbCity.Enabled = false;
		cbCity.SelectedValueChanged += new EventHandler(cbCity_SelectedValueChanged);
		panel.Controls.Add( cbCity );
	}
	void cbState_SelectedValueChanged( object sender, EventArgs e )
	{
		ComboBox cbState = sender as ComboBox;
		ComboBox cbCity = cbState.Tag as ComboBox;
		cbCity.Enabled = true;
		// .. Go ahead and populate cbCity by cbState's selected value ..
	}
	void cbCity_SelectedValueChanged( object sender, EventArgs e )
	{
		// Up to you...
	}
