    public enum Str
    {
    	Test = 1,
    	Exam = 2,
    	Mark = 4
    }
    
    private static void Main()
    {
    	Str test = (Str)5;  // Same as  test = Str.Test | Str.Mark;
    
    	if ((test & Str.Test) == Str.Test)
    	{
    		Console.WriteLine("Test");
    	}
    
    	if ((test & Str.Exam) == Str.Exam)
    	{
    		Console.WriteLine("Exam");
    	}
    
    	if ((test & Str.Mark) == Str.Mark)
    	{
    		Console.WriteLine("Mark");
    	}
    
    	Console.Read();
    }
