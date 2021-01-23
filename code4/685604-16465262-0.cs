    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
            Console.WriteLine(Convert("substringof('xxxx', [Property2])"));
            Console.WriteLine(Convert("[Property1] == 1234 and substringof('xxxx', [Property2]) and substringof('xxxx', [Property3])"));
            Console.WriteLine(Convert("substringof('xxxx', [Property2]) and [Property1] == 1234 and substringof('xxxx', [Property3])"));
    	}
        
        public static string Convert(string str)
        {
            Regex r = new Regex("(\\w+)\\(\\s*('[^']*')\\s*,\\s*([^)]+?)\\s*\\)");
            return r.Replace(str, new MatchEvaluator(MatchEvaluatorDelegate));
        }
        
        public static string MatchEvaluatorDelegate(Match m)
        {
            string answer = "";
            answer += m.Groups[3].Value + ".";
            answer += m.Groups[1].Value.Replace("substringof", "Contains");
            answer += "(" + m.Groups[2].Value + ")";
            return answer;
        }
    }
