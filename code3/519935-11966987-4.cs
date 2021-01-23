    public void OutputBtn_Click(object sender, EventArgs e)
    {
        foreach(var li in lb.Items)
        {
            PrintDocument PrintD = new PrintDocument();
            PrintD.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
            StreamReader sr = new StreamReader(li.ToString());
            PrintD.Print();        
        }
    }
