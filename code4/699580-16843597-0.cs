    private void buttonDoSomething_Click(object sender, EventArgs e)
    {
        List<Thread> t = new List<Thread>();
        for (int i = 0; i < 3; i++)
        {
            t.Add(new Thread (() => Console.Write(i)));
            t[i].Start();
        }
    }
