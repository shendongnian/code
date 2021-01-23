    bool _cancel = false;
    private void count()
    {
        _cancel = false;
        new System.Threading.Thread(delegate()
        {
            for (int i = 0; i < 100000; i++)
            {
                if (_cancel)
                    break;
    
                Console.WriteLine(i);
            }
        }).Start();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        _cancel = true;
    }
