	public void Charge(string paytype,orderNo){
	
	    IPayment paymentProcess = null;
	    PaymentModel payinfo = null;
	
	    if (Regex.IsMatch(paytype, "^Credit Card"))
	    {
	        paymentProcess = new SagePayment();
	        payinfo = getPaymentInfo(paytype, orderNo);
	    }
	    else if (Regex.IsMatch(paytype, "^PayPal"))
	    {
	        paymentProcess = new PayPalPayment();
	        payinfo = getPaymentInfo(paytype, orderNo);
	    }
	    else if (Regex.IsMatch(paytype, "^Google"))
	    {
	        paymentProcess = new GooglePayment();
	        payinfo = getPaymentInfo(paytype, orderNo); 
	    }
	
	    paymentProcess.MakePayment(payinfo);
	}
	
	public PaymentModel getPaymentInfo(string paytype,orderNo)
	{
		//return some payment model
	}
