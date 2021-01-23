    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (r.Contains(e.X, e.Y) && !entered)
        {
            entered = true;
            Invalidate(r);
        }
        else if (!r.Contains(e.X, e.Y) && entered)
        {
            entered = false;
            Invalidate(r);
        }
    }
