    private void button1_Click(object sender, EventArgs e)
    {
        // Set c to 100
        int c=100;
        // Print the result of Count, which will be 215.
        MessageBox.Show(Count(c).ToString());
    }
    
    public int Count(int a)
    {
        // Add 115 to a.
        a+=115;
        // Return the result (if a == 100, this will return 215)
        return a;
    }
