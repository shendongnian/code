    class EnergyProvider
    {
       void FillUp(ElectricVehicle c)
       {
          c.FillUpEnergy(...);
       }
       void FillUp(FuelVehicle c)
       {
          c.FillUpEnergy(...);
       }
    }
    energyProvider.FillUp(vehicle);
