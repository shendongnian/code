         private void textBox1_KeyDown(object sender, KeyEventArgs e)   
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
    
    
      
            public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
            {
                // Unselect the previously searched string
                if (searchStart > 0 && searchEnd > 0 && indexOfSearchText >= 0)
                {
                    richTextBox1.Undo();
                }
    
                // Set the return value to -1 by default.
                int retVal = -1;
    
                // A valid starting index should be specified.
                // if indexOfSearchText = -1, the end of search
                if (searchStart >= 0 && indexOfSearchText >= 0)
                {
                    // A valid ending index
                    if (searchEnd > searchStart || searchEnd == -1)
                    {
                        // Find the position of search string in RichTextBox
                        indexOfSearchText = richTextBox1.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
                        // Determine whether the text was found in richTextBox1.
                        if (indexOfSearchText != -1)
                        {
                            // Return the index to the specified search text.
                            retVal = indexOfSearchText;
                        }
                        else
                        {
                            start = 0;
                            indexOfSearchText = 0;
                            //return indexOfSearchText;
                        }
                    }
                }
                return retVal;
    
            }
    
     private void textBox1_TextChanged(object sender, EventArgs e)
            {
               
                
                start = 0;
                indexOfSearchText = 0;
                string temp = richTextBox1.Text;
                richTextBox1.Text = string.Empty;
                richTextBox1.Text = temp;
                richTextBox1.SelectionBackColor = Color.White;
            }
