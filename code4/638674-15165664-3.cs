    private void button_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            int lineNumber = Array.IndexOf(buttons, button);
            if (lineNumber >= 0)
            {
                ReplaceLineInFile(fileName, lineNumber, textBoxes[lineNumber].Text);
            }
        }
    }
