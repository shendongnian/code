    private void buttonSQL_Click(object sender, EventArgs e)
    {
        // Get unsaved input from text box
        string input = textBox1.Text;
        string[] inputLines = input.Split('\n');
           
        // Find and process relevant input
        foreach(string line in inputLines)
        {
            if (line.EndsWith("\r")) // Make sure line is complete
            {
                if (line.StartsWith("Today's total users: "))
                {
                    string dayUsers = line.Substring(20).Trim();
                    textDU.Text = dayUsers.ToString();
                    // SQL query...
                }
                else if (line.StartsWith("All-time total users: "))
                {
                    string dayUsers = line.Substring(21).Trim();
                    textAU.Text = allUsers.ToString();
                    // SQL query...
                }
            }
        }
        // Only keep unparsed text in text box
        textBox1.Text = inputLines[inputLines.Length - 1];
    }
