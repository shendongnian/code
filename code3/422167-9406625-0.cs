    interface IDeliveryService<F> where F : Freight
    {
    	void Deliver();
    }
    
    class RollerBladesDeliveryService<F> : IDeliveryService<F> where F: Freight
    {
    	public RollerBladesDeliveryService(RollerBladesDeliveryInformation<F> information){ ...	}
    
    	void Deliver() { ... }
    }
    
    class RollerBladesDeliveryInformation<F> where F: Freight
    {
    	public RollerBladesDeliveryInformation(F freight, double centerOfMass) { ... }
    }
