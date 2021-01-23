    Stopwatch timer = new Stopwatch();
    timer.Start();
    while (timer.ElapsedMilliseconds < 3000) {
        if (timer.ElapsedMilliseconds % 1000 == 0)
        {
            label1.Text = timer.ElapsedMilliseconds.ToString();
        }
    }
    timer.Stop();
