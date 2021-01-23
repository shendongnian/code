	public class CustomerRequestHandler : IRequestHandler<CustomerRequest, CustomerResponse>
	{
		public CustomerResponse ProcessRequest(CustomerRequest request)
		{
			return new CustomerResponse { Success = true };
		}
	}
	public class BillRequestHandler : IRequestHandler<BillRequest, BillResponse>
	{
		public BillResponse ProcessRequest(BillRequest request)
		{
			return new BillResponse { Success = false };
		}
	}
