    private Random Rand = new Random();
    
    private int RollCount;
    private int RollLimit;
    
    private void begingameButton_Click(object sender, EventArgs e)
    {
        RollCount = 0;
        RollLimit = Rand.Next(1, 25);
        //...other prep work
    }
    private void rolldieButton_Click(object sender, EventArgs e)
    {
        RollCount++;
        if (RollCount == RollLimit)
        {
            // limit reached
        }
    }
