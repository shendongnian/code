    List<string> errors = new List<string>();
    if (input == string.Empty)
    {
        errors.Add("Nothing to encrypt.");
    }
    if (typeComboBox.Text == null)
    {
        errors.Add("Nothing selected.");
    }
    if (errors.Count != 0)
    {
        MessageBox.Show(string.Join(" ", errors.ToArray()));
        return null;
    }
