    private void CommentMenuItemClick(object sender, EventArgs e)
    {
        StringWriter sw = new StringWriter();
    
        string line;
        StringReader rdr = new StringReader(rtb.SelectedText);
        line = rdr.ReadLine();
        while(line != null)
        {
                sw.AppendLine(IsNullOrWhiteSpace(line) ? "//" : "" + line);
                line= rdr.ReadLine();
        }
        rtb.SelectedText = sw.ToString();
        lb.Hide();
    }
