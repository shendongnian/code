    Try This Code:
        int timezone = 0;
          
        This string gives 12-hours formate
        string time = DateTime.Now.AddHours(-timezone).ToString("hh:mm:ss tt");
        This string gives 24-hours formate
        string time = DateTime.Now.AddHours(-timezone).ToString("HH:mm:ss tt");
