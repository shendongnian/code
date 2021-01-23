	//not sure on the exact signature since you didn't provide it
	public IPayment CreatePayment(string paytype)
	{
		IPayment paymentProcess = null;
		
		if (Regex.IsMatch(paytype, "^Credit Card"))
		{
		    paymentProcess = new SagePayment();
		}
		else if (Regex.IsMatch(paytype, "^PayPal"))
		{
		    paymentProcess = new PayPalPayment();
		}
		else if (Regex.IsMatch(paytype, "^Google"))
		{
		    paymentProcess = new GooglePayment();
		}
		
		return paymentProcess
	}
