	bool loop;
	do{
		Console.Write("Please give the value no "+ index + " :");
		if (!int.TryParse(Console.ReadLine(), out num))	//I find "!" easier to read then "false == "
		{ 
			Console.WriteLine("Your input is not valid, please try again.");
			Console.WriteLine();
			loop = true;
		}
		else
		{
			loop = false;
		}
	}while(loop);
