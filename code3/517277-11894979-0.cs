    void ParseLine(string line)
        {
            Regex r = new Regex("([ \\t{}():;])");
            String[] tokens = r.Split(line);
            foreach (string token in tokens)
            {
                // Set the tokens default color and font.
                richTextBox1.SelectionColor = Color.Black;
                richTextBox1.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                // Check whether the token is a keyword. 
                String[] keywords = { "Author", "Date", "Title", "Description", };
                for (int i = 0; i < keywords.Length; i++)
                {
                    if (keywords[i] == token)
                    {
                        // Apply alternative color and font to highlight keyword.
                        richTextBox1.SelectionColor = Color.Blue;
                        richTextBox1.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }
                }
                richTextBox1.SelectedText = token;
            }
           richTextBox1.SelectedText = "\n";
        }
