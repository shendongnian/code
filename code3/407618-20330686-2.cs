    public void SortLines(object sender, EventArgs e)
    {
            rtb.HideSelection = false; //for showing selection
            /*Saving current state*/
            string selectedText = rtb.SelectedText;
            /*Sorting*/
            string[] lines = rtb.Lines;
            Array.Sort(lines, delegate(string str1, string str2) { return str1.CompareTo(str2); });
            rtb.Lines = lines;
           /*restoring selection*/
            int newIndex = rtb.Text.IndexOf(selectedText);
            rtb.Select(newIndex, selectedText.Length);
    }
