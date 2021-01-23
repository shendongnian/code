        string inputDate = int.Parse(textBox54.Text)+"-"+int.Parse(textBox53.Text)+"-"+int.Parse(textBox52.Text);
        DateTime dateOfBirth ;
        var DateFormat = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
        if (DateTime.TryParseExact(inputDate, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth ))
        {
           //Valid Date
          //Call DB here
        }
        else
        {
            // Invalid Date
        }
