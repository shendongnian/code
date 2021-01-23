    static double Rate = 20.0; // 20$ per hour 9am to 5pm    
    static double TotalPayment(DateTime startTime, DateTime endTime)
    {
      if (startTime > endTime)
        throw new ArgumentException("start must be before end");
      if (startTime.Date != endTime.Date)
        throw new NotImplementedException("start and end must be on same day");
      double totalHours = (endTime - startTime).TotalHours;
      double startOfOrdinaryRate = Math.Max(9.0, startTime.TimeOfDay.TotalHours);
      double endOfOrdinaryRate = Math.Min(17.0, endTime.TimeOfDay.TotalHours);
      double ordinaryHours;
      if (startOfOrdinaryRate > endOfOrdinaryRate)
        ordinaryHours = 0.0;
      else
        ordinaryHours = endOfOrdinaryRate - startOfOrdinaryRate;
      return 1.0 * Rate * ordinaryHours
        + 1.5 * Rate * (totalHours - ordinaryHours);
    }
