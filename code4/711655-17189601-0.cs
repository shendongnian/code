    void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      RunOnUiThread(() =>
                    {
      txtDays = FindViewById<TextView> (Resource.Id.txtDays);
      txtHours = FindViewById<TextView> (Resource.Id.txtHours);
      txtMins = FindViewById<TextView> (Resource.Id.txtMins);
      txtSec = FindViewById<TextView> (Resource.Id.txtSec);
      DateTime enteredDate = new DateTime(2013, 7, 25, 12 ,30 ,00);
      DateTime todaysDateTime = DateTime.Now;
      DateTime formattedDate = todaysDateTime.AddHours (2);
      TimeSpan span = enteredDate.Subtract(formattedDate);
      totalDays = span.TotalDays;
      totalHours = span.TotalHours;
      totalMins = span.TotalMinutes;
      totalSec = span.TotalSeconds;
      Console.WriteLine ("Days: " + String.Format("{0:0}", Math.Truncate(totalDays)));
      Console.WriteLine ("Hours: " + String.Format("{0:0}", Math.Truncate(totalHours)));
      Console.WriteLine ("Minutes: " + String.Format("{0:0}", Math.Truncate(totalMins)));
      Console.WriteLine ("Seconds: " + String.Format("{0:0}", Math.Truncate(totalSec)));
      txtHours.Text = String.Format ("{0:0}", Math.Truncate (totalHours));
      txtHours.Text = String.Format ("{0:0}", Math.Truncate (totalHours));
      txtMins.Text = String.Format ("{0:0}", Math.Truncate (totalMins));
      txtSec.Text = String.Format ("{0:0}", Math.Truncate (totalSec));
      });
    }
