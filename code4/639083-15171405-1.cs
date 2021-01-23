    private List<string> autoCompleteList = new List<string>();
    public Form1()
    {
        autoCompleteList.Add("Items for the autocomplete");
    }
    ...
    
    private void textBox1_TextChanged(object sender, System.EventArgs e)
    {
        listBox1.Items.Clear();
        if (textBox1.Text.Length == 0)
        {
            hideAutoCompleteMenu();
            return;
        }
    
        Point cursorPt = Cursor.Position;
        listBox1.Location = PointToClient(cursorPt);
    
        foreach (String s in autoCompleteList)
        {
            if (s.StartsWith(textBox1.Text))
            {
                listBox1.Items.Add(s);
                listBox1.Visible = true;
            }
    
        }
     }
    
    private void hideAutoCompleteMenu()
    {
        listBox1.Visible = false;
    }
    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        hideAutoCompleteMenu();
    }
