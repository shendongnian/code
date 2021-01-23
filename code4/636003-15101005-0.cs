	var startDate = DateTime.Today;
	var endDate = DateTime.Today;
	var now = DateTime.Today;
	
	switch (option.ToUpper())
    {
        case "0":
            // CURRENT 15 days
            startDate = now.AddDays(-15);
			endDate = now;
            break;
        case "1":
            // LAST 30 days
            startDate = now.AddDays(-30);
			endDate = now;
            break;
        case "2":
            // CURRENT MONTH
            startDate = new DateTime(now.Year, now.Month, 1);
			endDate = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));
			break;
        case "3":
            // LAST MONTH
			var lastMonth = now.AddMonths(-1);
            startDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
			endDate = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
            break;
        case "4":
            // CURRENT YEAR
			startDate = new DateTime(now.Year, 1, 1);
			endDate = new  DateTime(now.Year, 12, 31);
            break;
        case "5":
            // LAST YEAR
			var lastYear = now.AddYears(-1);
			startDate = new DateTime(lastYear.Year, 1, 1);
			endDate = new  DateTime(lastYear.Year, 12, 31);
            break;
        default:
            break;
    }
	var users = Users.Where(u => u.RegisterDate >= startDate && u.RegisterDate <= endDate);
