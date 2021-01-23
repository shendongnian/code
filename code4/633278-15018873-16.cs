        public ActionResult Index(DateTime? start, string id = "")
        {
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
            // example InputData - Array as it might be returned by the sql procedure
            /* I added this Array to simulate a possible procedure result your DB could return,
               maybe you can even add a new procedure that would return the data just as in the
               following Array
            */
            var input = new [] { 
               new InputData( 40501, 1, 1, new DateTime(2013, 02, 20), "09:00"),
               new InputData( 40502, 1, 2, new DateTime(2013, 02, 20), "11:00"),
               new InputData( 42501, 1, 3, new DateTime(2013, 02, 23), "10:00"),
               new InputData( 42502, 1, 3, new DateTime(2013, 02, 23), "10:30"),
               new InputData( 45001, 2, 3, new DateTime(2013, 02, 21), "13:00"),
               new InputData( 45002, 2, 4, new DateTime(2013, 02, 22), "15:30"),
               new InputData( 47001, 2, 5, new DateTime(2013, 02, 24), "10:00"),
               new InputData( 47002, 2, 5, new DateTime(2013, 02, 24), "10:30"),
            };
            // receive all the stored_procedures
            i = 0;
            Mystaff MyStaff = new Mystaff()
            {
                staff = (from staff in staffids
                         select new Staff()
                         {
                             StaffID = staff.sid,
                             BusinessID = staff.bid,
                             SlotDates = (from day in days
                                          select new SlotDate()
                                          {
                                              Date = day.ToShortDateString(),
                                              SlotDay = day.DayOfWeek.ToString(),
                                              slots = ( from result in input
                                                        where // filter Slots that fit the requirements
                                                            day == result.SlotDate
                                                            && result.StaffID == staff.sid
                                                            && result.BusinessID == staff.bid
                                                       select new TimeSlot()
                                                       {
                                                           SlotID = result.SlotID,
                                                           SlotTime = result.SlotTime
                                                       }
                                                      ).ToArray()
                                          }
                                         // filter out days that don't have free slots
                                         ).Where(x => x.slots.Length > 0).ToArray()
                         }
                        ).ToArray()
            };
                             
            return Json(new { MyDates, MyStaff}, JsonRequestBehavior.AllowGet);
        }
    }
