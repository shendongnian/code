      using System;
      using System.Collections.Generic;
      using System.Globalization;
      using System.Linq;
      using System.Text;
      using System.Web;
      using System.Web.Mvc;
 
     namespace AntiYes.Helpers
    {
    public static class CalendarExtensions
    {
        public static IHtmlString Calendar(this HtmlHelper helper, DateTime dateToShow)
        {
            DateTimeFormatInfo cinfo = DateTimeFormatInfo.CurrentInfo;
            StringBuilder sb = new StringBuilder();
            DateTime date = new DateTime(dateToShow.Year, dateToShow.Month, 1);
            int emptyCells = ((int)date.DayOfWeek + 7 - (int)cinfo.FirstDayOfWeek) % 7;
            int days = DateTime.DaysInMonth(dateToShow.Year, dateToShow.Month);
            sb.Append("<table class='cal'><tr><th colspan='7'>" + cinfo.MonthNames[date.Month - 1] + " " + dateToShow.Year + "</th></tr>");
            for (int i = 0; i < ((days + emptyCells) > 35 ? 42 : 35); i++)
            {
                if (i % 7 == 0)
                {
                    if (i > 0) sb.Append("</tr>");
                    sb.Append("<tr>");
                }
 
                if (i < emptyCells || i >= emptyCells + days)
                {
                    sb.Append("<td class='cal-empty'>&nbsp;</td>");
                }
                else
                {
                    sb.Append("<td class='cal-day'>" + date.Day + "</td>");
                    date = date.AddDays(1);
                }
            }
            sb.Append("</tr></table>");
            return helper.Raw(sb.ToString());
        }
    }
}
