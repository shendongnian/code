	// Your controller class
    // (You could add a Route attribute here)]
	public class Estate
	{
        // Directly apply a route (or 2?!) to this action
		[Route("estate-support/deal-closing")]
		[Route("clinched")] // You can add multiple routes if required
		public ActionResult CloseDeal()
		{
			...
		}
		// And of course you can parameters to the route too, such as:
		[Route("customers/{customerId}/orders/{orderId}")]
		public ActionResult GetOrderByCustomer(int customerId, int orderId)
		{
			...
		}
		
		...
	}
	
