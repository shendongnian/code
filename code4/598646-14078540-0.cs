    private void UpdateTextBox(int row, int column, string text)
    {
        TextBox textBox = container.FindName("_" + row + "_" + column) as TextBox;
        if(textbox != null)
        {
            textbox.Text = text;
        }
    }
