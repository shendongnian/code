    private void button1_Click(object sender, EventArgs e)
    {
        // Set c to 100
        int c=100;
        // Print the result of Count, which (see below) is ALWAYS 115.
        MessageBox.Show(Count(c).ToString());
    }
    
    public int Count(int a)
    {
        // Set a to 115 (there is no add here, I think this is a typo)
        a=115;
        // Return a, which is ALWAYS 115.
        return a;
    }
