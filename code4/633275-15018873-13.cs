       public ActionResult Index(DateTime? start, string id = "0-1,0-2")
            var startdate = start ?? DateTime.Today;
            // split the input into anonymous objects containing staffid and businessid
            var staffids = from staffid in id.Split(',').Select(x => x.Split('-'))
                           select new { sid = int.Parse(staffid[0]), bid = int.Parse(staffid[1]) };
            // get the days you need
            var days = Enumerable.Range(0, 7).Select(x => startdate.AddDays(x));
            // create myDates
            int i = 0;
            Mydate MyDates = new Mydate() {
                ndate = days.First().AddDays(7).ToString("yyyy-MM-dd"),
                pdate = days.First().AddDays(-7).ToString("yyyy-MM-dd"),
                dates = (
                            from day in days
                                select new MyDateNDay { 
                                   date = day.ToShortDateString(), 
                                   day  = day.DayOfWeek.ToString()
                                }
                        ).ToArray()
            };
            // receive all the stored_procedures
            i=0;
            var models = from doc in staffids 
                         select new KeyValuePair<string, object>(
                             String.Format("doc{0}", i++),
                             (from day in days
                             select db.SP_GetAvailableAppointments(doc.did, day, doc.businessid)).ToList()
                         );
            return Json(new { MyDates }, JsonRequestBehavior.AllowGet);
       }
