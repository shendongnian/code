    private void button1_Click(object sender, EventArgs e)
    {
        int counter = TotalLines(date);
        if (counter <= 13)
        {
            MessageBox.Show("Seats Available");
        }
        else
        {
            MessageBox.Show("please chose another date");
        }
    }
    public int TotalLines(string date)
    {
        using (StreamReader r = new StreamReader(date))
        {
            int i = 0;
            while (r.ReadLine() != null) { i++; }
            return i;
        }     
    }
