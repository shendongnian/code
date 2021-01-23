    public void button2_Click(object sender, EventArgs e)
    {
        DateTime startTime = DateTime.Now;
        // code for archiving, streams
        TimeSpan diff = DateTime.Now - startTime;
        MessageBox.Show("Archive was created! in " + diff.TotalSeconds + " seconds.");
    }
