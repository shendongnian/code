    DateTime result;
    
    DateTime.TryParse("5 PM", out result);
    DateTime.TryParse("1:00", out result);
    DateTime.TryParse("1:00 AM", out result);
    DateTime.TryParse("12:00", out result);
    DateTime.TryParse("18:00", out result);
