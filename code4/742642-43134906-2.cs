	private DataGridViewCell CreateAnswerCell(AnswerType answerType)
	{
		// type of column depends on rowIndex
		DataGridViewCell cell;
		switch (answerType)
		{
			case AnswerType.YesNo: // Create a checkbox cell
				cell = new DataGridViewCheckBoxCell()
				{
					ValueType = typeof(bool),
					Value = false,
				};
				break;
			case AnswerType.LoadFile: // Create a Button cell
				cell = new DataGridViewButtonCell()
				{
					ValueType = typeof(string),
					Value = "Load!",
				};
				break;
			case AnswerType.Combo: // Create a Combo Cell
				var selectableValues = Enumerable.Range(0, 4);
				var comboItems = Enumerable.Range(0, 100);
				cell = new DataGridViewComboBoxCell()
				{
					DataSource = new BindingList<int>(comboItems.ToList()),
				};
				break;
			default: // Create a Text cell
				cell = new DataGridViewTextBoxCell()
				{
					ValueType = typeof(string),
					Value = "<please enter name>",
				};
				break;
		}
		return cell;
	}
