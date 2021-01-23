    public ComplexModelFromMultipleTables GetObject
    using (var db = new DBContext())
    {
        var model = new ComplexModelFromMultipleTables
        {
            Cars = db.Cars.Where(x => x.CarType == whateveryouwant).ToList(),
            Bikes = db.Bikes.Where(x => x.anotherproperty == whateveryouwant).ToList(),
            Boats = db.Boats.Where(x => x.something else == whateveryouwant).ToList(),
        }
        return model;
    }
