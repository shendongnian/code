    while (Counter < 5)
            	{
               	ActualGrowth = Population[Counter] + MathPercentage;
    
               	Counter++;
     
               	Population[Counter] = ActualGrowth + Population[Counter-1];
            	}
    
            	for (int i = 0; i < Population.Length; i++)
            	{
                Console.WriteLine("Population of 201{0:d}", Years[i]);
                Console.WriteLine(Population[i]);
            	}
            
