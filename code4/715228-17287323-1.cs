    return from P in db.ClassRooms
               where P.LocationId == LocationId && P.IsApproved==true
               select new ClassRoomsViewModel
               {
                   Id = P.Id,
                   Created = P.CreatedOn,
                   IsApproved = P.IsApproved,
                   IsDeleted = P.IsDeleted,
                   Desks = P.Desks.Name.Zip(P.Desks.Id,
                               (n, i) => new DeskViewModel { Id = i, Name = n });
               }
