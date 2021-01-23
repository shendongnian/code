	private void Button_Click(object sender, RoutedEventArgs e)
    {		
        TextBox input = ((TextBox)MyComboBox.Template.FindName("PART_EditableTextBox", MyComboBox));
        MessageBox.Show(input.Text.ToString());	
	}
