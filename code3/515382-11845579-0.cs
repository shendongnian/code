	StringBuilder MessageText = new StringBuilder();
	MessageText.AppendLine(string.Format("Coil#: {0}", coil_Num.Text));
	MessageText.AppendLine(string.Format("Location: {0}", location_box.Text));
	MessageText.AppendLine(string.Format("Sub-Area: {0}", sub_area_box.Text));
	MessageText.AppendLine(string.Format("Row: {0}", row_Num.Text));
	MessageText.AppendLine("Is this information correct?");
	DialogResult result1 = MessageBox.Show(MessageText.ToString(),
		"Double Check Form Information",
		MessageBoxButtons.YesNoCancel,
		MessageBoxIcon.Question);
