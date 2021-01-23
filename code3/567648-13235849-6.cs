    object paymentProcess;
    
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
