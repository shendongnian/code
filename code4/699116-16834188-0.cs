	public static Dictionary<int, Payment_Type> PaymentTypeList()
	{
		var pay = new Dictionary<int, Payment_Type>();
		pay.Add(1, new Payment_Type(1, "Cheque"));
		pay.Add(2, new Payment_Type(2, "Demand Draft"));
		pay.Add(3, new Payment_Type(3, "Cash"));
		pay.Add(4, new Payment_Type(4, "Other"));
		return pay;
	}
