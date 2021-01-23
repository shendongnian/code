    public void countDown(int integer)
    {
        if (integer == 1)
        {
            ListBox1.Items.Add(integer.ToString());
        }
        else
        {
            ListBox1.Items.Add(integer.ToString());
            integer--;
            countDown(integer);
        }
    } 
