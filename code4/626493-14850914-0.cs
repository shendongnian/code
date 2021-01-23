    private IList<PaymentItemViewModel> paymentItems = new List<PaymentItemViewModel>();
    
    public IEnumerable<PaymentItemViewModel> PaymentItems
    {
        get { return paymentItems; }
        set { paymentItems = value.ToList(); }
    }
