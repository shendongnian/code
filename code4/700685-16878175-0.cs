        [TestFixture]
        public class TestHarnessLite
        {
    	
    	[TestCase("add", "5+10", ArithmeticOperation.Addition, 15.0d)]
    	[TestCase("subtract", "5-10", ArithmeticOperation.Subtraction, -5.0d)]
    	[TestCase("multiply", "5*10", ArithmeticOperation.Multiplication, 50.0d)]
    	[TestCase("divide", "10/5", ArithmeticOperation.Division, 2.0d)]
    	public void SomeTest(string scenario, string textInput, ArithmeticOperation expectedOperation, double expectedValue)
    	{
    		//arrange
    		var math = new SimpleExpressionCalculator();
    		
    		//act
    		var actual = math.Calculate(textInput);
    		var actualOperator = math.Operation;
    		
    		//assert
    		Assert.That(actualOperator, Is.EqualTo(expectedOperation));
    		Assert.That(actual, Is.EqualTo(expectedValue), scenario);
    	}
    	
    }
    
        public enum ArithmeticOperation
        {
        	Unknown,
        	Addition,
        	Subtraction,
        	Multiplication,
        	Division
        }
    	
    public class SimpleExpressionCalculator
    {
    	public ArithmeticOperation Operation { get;set;}
    	
    	public double Calculate(string text)
    	{
    		var parsedValues = Parse(text);
    		switch (parsedValues.Item2)
    		{
    			case "+":
    				Operation = ArithmeticOperation.Addition;
    				return parsedValues.Item1 + parsedValues.Item3;
    			case "-":
    				Operation = ArithmeticOperation.Subtraction;
    				return parsedValues.Item1 - parsedValues.Item3;
    			case "*":
    				Operation = ArithmeticOperation.Multiplication;
    				return parsedValues.Item1 * parsedValues.Item3;
    			case "/":
    				Operation = ArithmeticOperation.Division;
    				if (parsedValues.Item3 == 0)
    					throw new DivideByZeroException("Can't divide by 0");
    				return (parsedValues.Item1 *(1.0d)) / ((1.0d)*parsedValues.Item3);
    		}
    		return 0.0;
    	}
    	
    	
    	public Tuple<int,string,int> Parse(string input)
    	{
    		var groups = Regex.Matches(input, @"\d+|[+-/*]+");
    		if (groups.Count != 3)
    			throw new ArgumentException("invalid input");
    		int operand1 = int.Parse(groups[0].Value);
    		string oper = groups[1].Value.Trim();
    		int operand2 = int.Parse(groups[2].Value);
    		return new Tuple<int, string, int>(operand1, oper, operand2);
    	}
    	
    }
