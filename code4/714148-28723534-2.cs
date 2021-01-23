    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var value =
    				"super exemple of string key : text I want to keep - end of my string"
    					.Between(
    				        "key : ",
    				        " - ");
    			
    		Console.WriteLine(value);
    	}
    }
    
    public static class Ext
    {
    	static string Between(this string source, string left, string right)
    	{
    		return Regex.Match(
    				source,
    				string.Format("{0}(.*){1}", left, right))
    			.Groups[1].Value;
    	}
    }
