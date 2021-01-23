     DateTimePicker newDate = (DateTimePicker)rootcontrol;
     String format = "H:mm";
     DateTime dDate;
         try
          {
            DateTime.TryParseExact(answer, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dDate);
           newDate.Format = DateTimePickerFormat.Custom;
            newDate.Value = dDate;
          }
           catch (System.ArgumentOutOfRangeException)
         {
            newDate.Text = answer;
            Console.WriteLine("ERROR SET TIME:" + answer);
          }
