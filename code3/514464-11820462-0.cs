    var EventList = (from b in db.bookings
                    select new DiaryEvent
                    {
                        AllDay = false,
                        Description = b.bookingDescription,
                        ID = b.bookingID,
                        StartDate = (DateTime)b.startDate,
                        EndDate = (DateTime)b.endDate,
                        EventTitle = b.bookingName,
                        Location = b.bookingLocation,
                        ResourceCalendarID = b.resourceID.ToString(),
                        ResourceColour = b.bookingColour.Trim()
                    }).ToList();
