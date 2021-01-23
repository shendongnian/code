    InputBoxResult InputDate = InputBox.Show("Please enter a Date:", 
                                             "Input Date",
                                             DateTime.Today.ToString("dd.MM.yyyy"));
    
    if (InputWorkspaceName.ReturnCode == DialogResult.OK)
    {
        RequestData(InputDate.Text);
    }
