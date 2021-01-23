        {
            if (e.KeyCode == Keys.Enter)
           
            
            {                   
                 int startindex = 0;
                if (textBox1.Text.Length > 0)
                {
                     
                    
                    startindex = FindMyText(textBox1.Text.Trim(), start, richTextBox1.Text.Length);
                    if (startindex == -1 && start >= 0) // Not found string and not searching from beginning
                    {
                        // Wrap search
                       // int oldStart = start;
                        start = 0;
                        startindex = FindMyText(textBox1.Text.Trim(), start, richTextBox1.Text.Length);
                    }
                    
                        
                }
                   
                // If string was found in the RichTextBox, highlight it
                if (startindex >= 0)
                {
                    // Set the highlight color as red
                    richTextBox1.Select(startindex, textBox1.TextLength);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                   // richTextBox1.SelectionColor = Color.Red;
                    // Find the end index. End Index = number of characters in textbox
                    int endindex = textBox1.Text.Length;
                    // Highlight the search string
                    richTextBox1.Select(startindex, endindex);
                    // mark the start position after the position of
                    // last search string
                    start = startindex + endindex;
                }
                
            }
        }
