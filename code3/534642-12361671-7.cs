    public static class ValidatableCustomOrderLoader
    {
    	public static ValidatableCustomOrder Get(int orderID)
    	{
    		ValidatableCustomOrder loadedOrder = LoadOrderFromSomewhere(orderID);
    		ValidatableCustomOrder copiedOrder = new ValidatableCustomOrder(loadedOrder);
    		return copiedOrder
    	}
    	
    	private ValidatableCustomOrder LoadOrderFromSomewhere(int orderID)
    	{
    		//get your order somehow
    	}
    }
