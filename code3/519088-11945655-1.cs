    private void TextBoxWorkflowCountTextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxWorkflowCount.Text))
            return;
        int workflowCount;
        if (int.TryParse(textBoxWorkflowCount.Text, out workflowCount))
        {
            if (workflowCount > 35)
            {
                MessageBox.Show("Number of workflow errors on one submission cannot be greater then 35.", "Workflow Count too high",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxWorkflowCount.Text = "35";
            }
        }
    }
