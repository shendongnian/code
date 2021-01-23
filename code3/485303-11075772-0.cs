	IList<int> shippedOrderNumbers = new List<int>();
	for (int = 0; i < 5; i++)
	{
		Console.WriteLine("Please input the Shipping Number: ");
		int shippingNumber;
		if (!Int.TryParse(Console.ReadLine(), out shippingNumber) 
		{
			Console.WriteLine("Your shipping number is not an integer");
		}
		if (shippedOrderNumbers.Contains(shippingNumber)) 
		{
			Console.WriteLine("This shipping number has already been entered.");
		}
		else 
		{
			shippedOrderNumbers.Add(shippingNumber);
			Console.WriteLine("Thanks for submitting your shipping number.");
		}
	}
