    var query = from h in _dataContext.Houses
                join a in _dataContext.PersonHouseAssignments 
                on h.Id equals a.HouseId into assignments
                select new 
                {
                   HouseName = p.HouseName, 
                   IsAssigned = assignments.Any(),
                   //..
                }
