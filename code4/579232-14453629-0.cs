    public void delay(int milliseconds)
    {
        DateTime dt = DateTime.Now + new TimeSpan(0, 0, 0, 0, millseconds);
        while(dt > DateTime.Now)
        {
            Application.DoEvents();
        }
    }
    
    public ConstructorNameHere
    {
        // Show Toast would go here.
        delay(1000); // Waits for 1 second
        MessageBox.Show("Hello World!");
    }
