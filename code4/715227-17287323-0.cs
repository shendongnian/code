    return from P in db.ClassRooms
               where P.LocationId == LocationId && P.IsApproved==true
               select new ClassRoomsViewModel
               {
                   Id = P.Id,
                   Created = P.CreatedOn,
                   IsApproved = P.IsApproved,
                   IsDeleted = P.IsDeleted,
                   Desks = String.Join(",",P.Desks.Select(d => d.Id).ToList())
            }
