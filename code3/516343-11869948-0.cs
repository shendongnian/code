    public int lHoursB
    {   
      get
      {
        int result = 0;
        int.TryParse(lHours.Text, out result);
        return result;
      }
      set
      {
        lHours.Text = value.ToString();
      }
    } 
