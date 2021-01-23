	public static class ThirdPartyLibHelper {
		public static void SetSecondDate(DateTime dateTime) {
			Thread.CurrentThread.CurrentCulture=new System.Globalization.CultureInfo("en-Us");
			var dateTimeFormat=Thread.CurrentThread.CurrentCulture.DateTimeFormat;
			dateTimeFormat.SetAllDateTimePatterns(new[] { "" }, 'T');
			dateTimeFormat.SetAllDateTimePatterns(new[] { "yyyy-MM-dd" }, 'd');
			thirdPartyLib.SetSecondDate(dateTime);
		}
		public static void SetFirstDate(DateTime dateTime) {
			Thread.CurrentThread.CurrentCulture=new System.Globalization.CultureInfo("en-Us");
			var dateTimeFormat=Thread.CurrentThread.CurrentCulture.DateTimeFormat;
			dateTimeFormat.SetAllDateTimePatterns(new[] { "" }, 'T');
			dateTimeFormat.SetAllDateTimePatterns(new[] { "dddd, MMMM dd, yyyy" }, 'd');
			thirdPartyLib.SetFirstDate(dateTime);
		}
	}
