    public ActionResult Index()
            {
                var model = new Home();
                model.Items = GetItems(DateTime.Now, DateTime.Now.AddDays(3));
                return View(model);
            }
    
            private List<SelectListItem> GetItems(DateTime start, DateTime end)
            {
                var dates = new List<DateTime>();
                for (double i = 0; i < 100; i++)
                {
                    dates.Add(start.AddDays(i + 1));
                }
    
                var selectList = new List<SelectListItem>();
                selectList.AddRange(dates.Select(x => new SelectListItem
                {
                    Selected = x.Date == end.Date,
                    Text = x.ToString("d.M.yyyy"),
                    Value = x.ToString("d/M/yyyy", new DateTimeFormatInfo())
                }));
    
                return selectList;
            }
