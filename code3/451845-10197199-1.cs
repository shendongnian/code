    public ActionResult Index(int? year = 2012 , int? month = 2)
            {
                ViewBag.Message = "Welcome to ASP.NET MVC!";
    
                Calendar monthEventsCal = new Calendar();
    
                HTMLMVCCalendar.Models.MonthModel allMonthEvents = monthEventsCal.monthEvents(year.Value, month.Value);
                return View("Index", allMonthEvents);
            }
    
            [HttpPost]
            public ActionResult Previous(int? year = 2012, int? month = 2)
            {
                Calendar monthEventsCal = new Calendar();
    
                var newMonth = monthEventsCal.previousMonth(year.Value, month.Value);
    
                int currMonth = newMonth.Item2;
                int currYear = newMonth.Item1;
    
                return RedirectToAction("Index", "Home", new { month = currMonth, year = currYear });
            }
    
            [HttpPost]
            public ActionResult Next(int? year = 2012, int? month = 2)
            {
                Calendar monthEventsCal = new Calendar();
    
                var newMonth = monthEventsCal.nextMonth(year.Value, month.Value);
    
                int currMonth = newMonth.Item2;
                int currYear = newMonth.Item1;
    
                return RedirectToAction("Index", "Home", new { month = currMonth, year = currYear });
            }
