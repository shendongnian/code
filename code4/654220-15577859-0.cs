	// All ints are "base 10"
	var thisIsAlreadyBase10 = 10;
	Console.WriteLine("The number {0} in base 10 is {0}", thisIsAlreadyBase10);
	
	// However, if you have a string with a non-base 10 number...
	var thisHoweverIsAStringInHex = "deadbeef";
	Console.WriteLine(
		"The hex string {0} == base 10 int value {1}", 
		thisHoweverIsAStringInHex, 
		Convert.ToInt32(thisHoweverIsAStringInHex, 16));
