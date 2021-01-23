	public static void Main()
	{
		var phoneUtil = PhoneNumberUtil.GetInstance();
		var numberProto = phoneUtil.Parse("(979) 778-0978", "US");
		var formattedPhone = phoneUtil.Format(numberProto, PhoneNumberFormat.INTERNATIONAL);
		Console.WriteLine(formattedPhone);
	}
