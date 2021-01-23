    private void RefreshButton_Click(object sender, EventArgs e)
    {
        //Assuming label1 is for the Ram
        label1.text = getRamString();
    }
    private string getRamString()
    {
        float ramValue = //Calculate the RAM
        return string.Format("{0}%", ramValue);
    }
