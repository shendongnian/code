    private void PrintTextboxValue()
    {
        Debug.WriteLine("Value: {0}", publicSearchTextBox.Text);
    }
    private void publicSearchTextBox_ActionIconTapped(object sender, EventArgs e)
    {
        PrintTextboxValue();
    }
    private void publicSearchTextBox_KeyUp(object sender, KeyEventArgs e)
    {
        PrintTextboxValue();
    }
