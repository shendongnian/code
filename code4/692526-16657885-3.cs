    public void writeLog(object state)
    {
        TimerState stateObj = (TimerState)state;
        Timer t = schedquery[stateObj.TimerIndex];
        //do queries and write results to file then check if the timer
        //has done certain amount of loops and dispose or restart
        schedValues.schedTurnCounter++;
        if (schedValues.schedTurnCounter == schedValues.schedTurns)
        {
            t.Dispose();
        }
        else
        {
            t.Change(1000 * 60 * schedValues.schedTimer, 0);
        }
    }
