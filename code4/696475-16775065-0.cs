     private void NodaTime(object sender, RoutedEventArgs e)
     {
         
         LocalDateTime DateToConvertFrom = new LocalDateTime(2014, 9, 6, 23, 12, 0);
      
         CalendarSystem CoptCal = CalendarSystem.GetCopticCalendar(1);
     
         String ConvertedTime = Convert.ToString(DateToConvertFrom.WithCalendar(CoptCal));
 
         String[] ConvertedTimeF=ConvertedTime.Split();
 
         YearTextBox.Text = String.Format(ConvertedTimeF[0].ToString() + "\n\n" + ConvertedTimeF[1].ToString());
     }
