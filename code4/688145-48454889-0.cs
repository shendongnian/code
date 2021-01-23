    public interface IDatabase {
        Vehicle GetVehicleByRegistrationNumber(string registrationNumber);
    }
    public interface IExternalManufactureSystem {
        Tyre GetTyreSpecification(long vehicleIdentifier);
    }
