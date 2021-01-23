    int totalSteps = 10;
    for (int i= 1; i<= totalSteps; i++)
    {
        //  One chunk of your code
    
        int progress = i * 100 / totalSteps;
        blocksProgressBar.Value = progress;
    }
    blocksProgressBar.Value = 0;
