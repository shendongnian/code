    bool pause = false;
  
    // Check ball[0] outside the loop for performance.
    if (blueBallPosition[0] < 360 && greenBallPosition[0] < 360)
    {
        pause = true;
        for (int i = 1; i < levelBall; i++)
        {
            if (blueBallPosition[i]  <= 360) || (greenBallPosition[i] <= 360))
            {
                pause = false;
                // You have found a ball that doesn't match, so no need
                // to keep checking.
                break;
            }
        }
    }
    
    
