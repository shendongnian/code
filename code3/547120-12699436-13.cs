	Attachvariable obj = new Attachvariable();
	
	obj.receiveData("userID", "9001");
	obj.receiveData("position", "Hello World!");
	obj.receiveData("yesno", "yes");
	obj.receiveData("ProperBoolean", "True");
	
	Console.WriteLine(obj.UserID); //9001
	Console.WriteLine(obj.Position); //"Hello World!"
	Console.WriteLine(obj.YesNo); //True
	Console.WriteLine(obj.ProperBoolean); //True
	
	obj.receiveData("yesno", "something else!");
	Console.WriteLine(obj.YesNo); //False
	
	obj.receiveData("ProperBoolean", "Invalid Boolean!"); //throws exception on `Boolean.Parse` step as intended
