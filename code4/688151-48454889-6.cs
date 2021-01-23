    public class Selecter : ISelecter {
        private IDatabase database;
        private IExternalManufactureSystem externalManufactureSystem;
        public Selecter(IDatabase database, IExternalManufactureSystem externalManufactureSystem) {
            this.database = database;
            this.externalManufactureSystem = externalManufactureSystem;
        }
        public Vehicle GetVehicleByRegistrationNumber(string registrationNumber) {
            //'Database will give us the vehicle specification'
            var vehicle = database.GetVehicleByRegistrationNumber(registrationNumber);
            //Then we do things with the vehicle object
            //Get the tyre specification
            vehicle.TyreSpecification = GetTyreSpecification(vehicle.VehicleIdentifier);
            return vehicle;
        }
        public Tyre GetTyreSpecification(long vehicleIdentifier) {
            //'external manufacture system gets the tyre specification'
            var tyre = externalManufactureSystem.GetTyreSpecification(vehicleIdentifier);
            //Then do thing with the tyre before returning the object
            return tyre;
        }
    }
