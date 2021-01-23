    // these have to be member variables, or you'll never be able to reset
    // or even remember the counter between calls
    private int clicks = 0;
    private int state = 0;
    // these are just so we don't have to repeat ourselves
    private string[] labels = { "TEXTBX 1", "TEXTBX 2", "ZZZZ" };
    private int[] max = { 34, 33, 33 };
    
    public void reset() {
        clicks = 0;
        state = 0;
    }
    public void bump()
    {
        // bump the counter, and if it's high enough, switch to the next state
        // and reset the counter
        // (the "% max.Length" causes 3 to be 0, so states wrap around)
        if (++clicks > max)
        {
             state = (state + 1) % max.Length;
             clicks = 0;
        }
        textBlock1.Text = labels[state];
        textBlock2.Text = clicks.ToString();
    }
