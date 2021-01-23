    void button_MouseUp(object sender, MouseEventArgs e)
    {
        Stopwatch watch = ((sender as Button).Tag as Stopwatch);
        watch.Stop();
        MessageBox.Show("This button was clicked for " + watch.Elapsed.TotalMilliseconds + " milliseconds");
        watch.Reset();
    }
    void button_MouseDown(object sender, MouseEventArgs e)
    {
        ((sender as Button).Tag as Stopwatch).Start();
    }
