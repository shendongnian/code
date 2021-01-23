    DateTime currentTime = DateTime.Now;
    DateTime startTime = DateTime.AddMinutes(-50D); //in your case this would be a DT todaysJob.STARTTIME.Value
    DateTime endTime = DateTime.AddMinutes(50);// in your case this would be a DT todaysJob.ENDTIME.Value
    
    if(currentTime > startTime && currentTime <= endTime)
    {
      Console.Write("Works Fine"); //your logic
    }
