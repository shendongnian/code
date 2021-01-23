    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string re = @"(?x)
    			^
    			# fail if...
    			(?!
    				# repeating numbers
    				(\d) \1+ $
    				|
    				# sequential ascending
    				(?:0(?=1)|1(?=2)|2(?=3)|3(?=4)|4(?=5)|5(?=6)|6(?=7)|7(?=8)|8(?=9)|9(?=0)){5} \d $
    				|
    				# sequential descending
    				(?:0(?=9)|1(?=0)|2(?=1)|3(?=2)|4(?=3)|5(?=4)|6(?=5)|7(?=6)|8(?=7)|9(?=8)){5} \d $
    			)
    			# match any other combinations of 6 digits
    			\d{6}
    			$
    		";
    		
    		string[] numbers = { "102", "111111", "123456", "654321", "123455", "321123", "111112" };
    		
    		foreach (var str in numbers)
    		{
    			Console.WriteLine(str);
    			Console.WriteLine(Regex.IsMatch(str, re) ? "\tMatched" : "\tFailed");
    		}
    	}
    }
