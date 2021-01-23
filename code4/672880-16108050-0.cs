    public static IEnumerable<Service> getAllService()
    {
        using (var db = new LocAppContext())
        {
            // var service = db.Locations.Include(s => s.LocationAssignment);
    
            var serv = (from s in db.Services
                        where s.active == true
                        select s).ToList();
            return serv;
        }
    }
