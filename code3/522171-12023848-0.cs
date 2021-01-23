	public class MyRegex : Regex
	{
		public String Pattern {protected set; get;}
		public MyRegex(String Pattern) : Regex(Pattern)
		{
				this.Pattern = Pattern;
		}
	}
