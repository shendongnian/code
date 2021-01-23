        string InputDate = "3/15/2013";
        string InputStartTime = "11:45 PM";
        string InputEndTime = "1:10 AM";
        DateTime StartTime, EndTime;
        StartTime = Convert.ToDateTime(InputDate + " " + InputStartTime);
        EndTime = Convert.ToDateTime(InputDate + " " + InputEndTime);
        if (EndTime < StartTime)
            EndTime += new TimeSpan(1, 0, 0, 0);
        string OutputStartTime = StartTime.ToString("MM/dd/yyyy HH:mm:ss");
        string OutputEndTime = EndTime.ToString("MM/dd/yyyy HH:mm:ss");
