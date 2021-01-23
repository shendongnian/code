    public class VehicleModel
    {
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public List<Cars> Cars { get; set; }
        public List<Bus> Buses { get; set; }
    }
    var vehicleID = 1; // just for the example of course.
    var fuelType = "Petrol";
    var vehicle = (from v in dc.vehicle 
                   where v._VehicleID == vehicleID
                   select new VehicleModel
                   {
                       VehicleID = v._VehicleID,
                       ModelID = v._ModelID,
                       Cars = v._AllCars.Where(car => car.Type == fuelType).ToList(),
                       Buses = v._AllBus.Where(bus => bus.Type == fuelType).ToList()
                   }).SingleOrDefault();
                   // use FirstOrDefault() when _VehicleID is NOT unique to get TOP 1
