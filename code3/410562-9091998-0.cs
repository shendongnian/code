    newRide.TimeDispatched = DateTime.Now;
    newRide.WaitTime = (((DateTime)newRide.TimeDispatched) - ((DateTime)newRide.TimeOfCall));
    newRide.AssignedCar = carNum;
    newRide.Status = "EnRoute";
    assignedCar.Status = "EnRoute";
    assignedCar.CurrPassengers = newRide.NumPatrons;
    assignedCar.StartAdd = newRide.PickupAddress;
    assignedCar.EndAdd = newRide.DropoffAddress;
    assignedCar.CurrentAdd = newRide.DropoffAddress;
    assignedCar.Rides = newRide; // Your First Change here
    myEntities.SaveChanges();
    
                       
