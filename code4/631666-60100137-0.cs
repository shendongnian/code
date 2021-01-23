	public static bool IsValidJson(this string src)
	{
		try
		{
			var asToken = JToken.Parse(src);
			return asToken.Type == JTokenType.Object || asToken.Type == JTokenType.Array;
		}
		catch (Exception)  // Typically a JsonReaderException exception if you want to specify.
		{
			return false;
		}
	}
Json.Net reference for `JToken.Type`: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JTokenType.htm
