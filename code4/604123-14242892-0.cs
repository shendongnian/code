    var statistics = 
         blogList.GroupBy(val => new {val.BlogDate.Month, val.BlogDate.Month.Year})
                 .OrderBy(item => item.Year)
                 .ThenBy(item => item.Month)
    	         .Select (grouped => new {Month = grouped.Key.Month, Year = grouped.Key.Year, Count = grouped.Count() });
    @foreach (var item in statistics)
    {
      var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Month);
      @Html.ActionLink(monthName + " " +  item.Year+ "("+ item.Count+")", "Archive", new  
      {
         year = item.Year, month = item.Month}) <br/>
      }
    }
