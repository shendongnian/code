    private void CommentMenuItemClick(object sender, EventArgs e)
    {
        StringBuilder sw = new StringBuilder();
    
        string line;
        StringReader rdr = new StringReader(rtb.SelectedText);
        line = rdr.ReadLine();
        while(line != null)
        {
                sw.AppendLine(String.IsNullOrWhiteSpace(line) ? "//" : "" + line);
                line= rdr.ReadLine();
        }
        rtb.SelectedText = sw.ToString();
        lb.Hide();
    }
