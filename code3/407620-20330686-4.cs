    public void SortLines(object sender, EventArgs e)
    {
           rtb.HideSelection = false; //for showing selection
            /*Saving current selection*/
            string selectedText = rtb.SelectedText;
            /*Saving curr line*/
            int firstCharInLineIndex = rtb.GetFirstCharIndexOfCurrentLine();
            int currLineIndex = rtb.Text.Substring(0, firstCharInLineIndex).Count(c => c == '\n');
            string currLine = rtb.Lines[currLineIndex];
            int offset = rtb.SelectionStart -firstCharInLineIndex;
            /*Sorting*/
            string[] lines = rtb.Lines;
            Array.Sort(lines, delegate(string str1, string str2) { return str1.CompareTo(str2); });
            rtb.Lines = lines;
            if (!String.IsNullOrEmpty((selectedText)))
            {
                /*restoring selection*/
                int newIndex = rtb.Text.IndexOf(selectedText);
                rtb.Select(newIndex, selectedText.Length);
            }
            else
            {   /*Restoring the cursor*/
                //location of the current line
                int lineIdx = Array.IndexOf(rtb.Lines, currLine);
                int textIndex = rtb.Text.IndexOf(currLine);
                int fullIndex = textIndex + offset;
                rtb.SelectionStart =  fullIndex;
                rtb.SelectionLength = 0;
            }
    }
