    if ((blueBallPosition[0]  < 360) && 
        (greenBallPosition[0] < 360))
    {
        pause = true;
        for (int i = 1; i < levelBall; i++)
        {
            if((blueBallPosition[i]  <= 360) || 
            (greenBallPosition[i] <= 360))
            { 
                pause = false;
            }
        }
    }
