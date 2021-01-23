    // these have to be member variables, or you'll never be able to reset
    // or even remember the counter between calls
    private int clicks = 0;  // the number of clicks in the current loop
    private int state = 0;   // which loop we're in
    // these are just so we don't have to repeat ourselves.
    // each element corresponds to a possible value of `state`.
    // both arrays should have the same number of elements.
    // alternatively, you could have a type that bundles the label and max together,
    // and just have an array of those.
    private string[] labels = { "TEXTBX 1", "TEXTBX 2", "ZZZZ" };
    private int[] max = { 34, 33, 33 };
    
    public void reset() {
        clicks = 0;
        state = 0;
        // probably reset text boxes here too
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
