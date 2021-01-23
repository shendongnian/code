    Settings1.Default.n.Clear()
    Settings1.Default.c.Clear()
    int count = 1
    while (count < 11)
    {
        Control n = panel2.Controls.Find("n" + count.ToString(), true).Single();
        Settings1.Default.n.Add(n.Text);
    
        Control c = panel2.Controls.Find("c" + count.ToString(), true).Single();
        Settings1.Default.c.Add(c.Text);
    
        count++;
    }
