    from guest in Guests
                    join rsvp in RSVPs.Where(o => o.EventID == "1234")
                    on guest.UserName equals rsvp.UserName into sr
                    from x in sr.DefaultIfEmpty()
                    select new
                    {
                         guest,
                        guest.RSVPs.Where(o => o.EventID =="1234")
                                   .OrderByDesc(o=>o.SubmittedDate)
                                   .FirstOrDefault()
                    }
