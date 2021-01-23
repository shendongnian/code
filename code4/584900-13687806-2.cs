    private void button1_Click(object sender, EventArgs e)
    {
        // Set c to 100
        int c=100;
        // Call the count function, passing in a reference for c.
        Count(ref c);
        // Print the value of c. This will be 215 because the Count function set c to a new value.
        MessageBox.Show(c.ToString());
    }
    
    public void Count(ref int a)
    {
        a+=115;
    }
