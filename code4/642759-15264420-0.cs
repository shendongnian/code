    public int GetDays(DateTime date)
    {
    
      return date.Subtract(DateTime.Now).Days;
    }
