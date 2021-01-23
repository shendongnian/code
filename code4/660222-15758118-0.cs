	var generatedNum = new List<int>();
	int tempo;
	Random random = new Random();
	while(true)
	{
		tempo = random.Next(0, 25);
		if(!generatedNum.Contain(tempo))
		{
			generatedNum.Add(tempo);
			
			if(tempo.Count == 10)
			{
				break;
			}
		}
	}
	foreach (int i in generatedNum)
	{
		Console.WriteLine("{0}", int);
	}
    }
