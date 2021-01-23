    try
    {
      String formattedDate = DateTime.Now.ToString(dateFormat);
      DateTime.Parse(formattedDate);
      return true;
    }
    catch (Exception)
    {
      return false;
    }
