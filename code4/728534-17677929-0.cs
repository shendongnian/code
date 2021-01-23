    static void Main()
    {
    	Console.WriteLine("Name: ");
            string sname=Consolre.ReadLine();
            while(sname != "Exit")
    	{
    		Console.WriteLine("Enter the no:of Quizes: ");
              	int numOfQuiz=Convert.ToInt32(Console.ReadLine());
    		int score=0,totalQuiz=numOfQuiz;
    		while(numOfQuiz>0)
    		{
    			Console.WriteLine("Enter the score for Quiz {0}",totalQuiz-numOfQuiz+1);
    			score+=Convert.ToInt32(Console.ReadLine());
    			numOfQuiz--;
    		}
    		score = score/numOfQuiz;
    		if(score>90)
    			Console.WriteLine("A");
    		else if(score >70)
    			Console.WriteLine("B");
    		else
    			Console.WriteLine("C");
    		Console.WriteLine("Enter another name or exit? ");
    		sname=Console.ReadLine();
    	}
    }
