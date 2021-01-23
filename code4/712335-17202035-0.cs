    public ActionResult List()
            {
                var currentDate = DateTime.Now;
                var list = new List<ArchiveViewModel>();
                for (var startDate = currentDate; startDate >= new DateTime(2012, 11, 1); startDate = startDate.AddMonths(-1))
                {
                    list.Add(new ArchiveViewModel
                    {
                        Month = startDate.Month,
                        Year = startDate.Year,
                        FormattedDate = startDate.ToString("MMMM, yyyy")
                    });
                }
                return View("List",list);
            }
