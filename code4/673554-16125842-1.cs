    public void countDown(int integer)
    {
        if (integer > 0)
        {
            ListBox1.Items.Add(integer.ToString());
            integer--;
            countDown(integer);
        }
    } 
