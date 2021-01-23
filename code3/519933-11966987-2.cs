    public void OutputBtn_Click(object sender, EventArgs e)
    {
        foreach(ListItem li in lb.Items)
        {
            PrintDocument PrintD = new PrintDocument();
            PrintD.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
            StreamReader sr = new StreamReader(li.Value);
            PrintD.Print();        
        }
    }
