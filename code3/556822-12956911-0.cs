    private class VehicleHolder
    {
        public DateTime Date { get; set;}
        public object Vehicle { get;set; }
    }
    
    //...
    
    var cars = (from x in db.tblCar 
                select new VehicleHolder() { Date = x.car_date, Vehicle = x }).ToList();
    var planes = (from x in db.tblPlane 
                  select new VehicleHolder() { Date = x.pl_date, Vehicle = x }).ToList();
    
    var result = cars.Concat(planes).OrderBy(v => v.Date).Select(v => v.Vehicle);
