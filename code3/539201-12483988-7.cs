    public object Foo(IVehicle vehicle, string obstacle)
    {                              
        if(!vehicle.CanCross(obstacle)) {
            var altVehicle = vehicle.CreateAlternativeVehicle();
            if (altVehicle == null) {
                return null;
            }
            return Foo(altVehicle, obstacle);
        }
        ...
    }
