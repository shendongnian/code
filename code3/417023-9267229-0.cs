    var query = from p in _dataContext.Houses
                join a in _dataContext.PersonHouseAssignments.DefaultIfEmpty()
                on h.Id equals a.HouseId
                select new 
                {
                   HouseNames = p.HouseName, 
                   IsAssigned = a != null, 
                   Description = a != null ? a.Description : string.Empty
                }
