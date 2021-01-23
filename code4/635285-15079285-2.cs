	private void button1_Click( object sender, EventArgs e ) {
		String value = "30d";
		Duration d = (Duration)Enum.Parse(typeof(Duration), value.Substring(value.Length - 1, 1).ToUpper());
		DateTime result = d.From(new DateTime(), value);
		MessageBox.Show(result.ToString());
	}
    enum Duration { D, W, M, Y };
    
    static class DurationExtensions {
    	public static DateTime From( this Duration duration, DateTime dateTime, Int32 period ) {
    		switch (duration)
    		{
    		  case Duration.D: return dateTime.AddDays(period);
    		  case Duration.W: return dateTime.AddDays((period*7));
    		  case Duration.M: return dateTime.AddMonths(period);
    		  case Duration.Y: return dateTime.AddYears(period);
    		  default: throw new ArgumentOutOfRangeException("duration");
    		}
    	 }
		public static DateTime From( this Duration duration, DateTime dateTime, String fullValue ) {
			Int32 period = Convert.ToInt32(fullValue.ToUpper().Replace(duration.ToString(), String.Empty));
			return From(duration, dateTime, period);
		}
    }
