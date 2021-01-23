    private void buttonDoSomething_Click(object sender, EventArgs e)
    {
        List<Thread> t = new List<Thread>();
        string[] bla = textBoxBla.Lines;
        for (int i = 0; i < bla.Length; i++)
        {
            int y = i; 
            //note the line above, that's where I make the int that the lambda has to grab
            t.Add(new Thread (() => some_thread_funmction(bla[y]))); 
            //note that I don't use i there, I use y.
            t[i].Start();
        }
    }
