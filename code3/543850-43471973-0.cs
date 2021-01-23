    public static string JsonToQuery(this string jsonQuery)
		{
			string str = "?";
			str += jsonQuery.Replace(":", "=").Replace("{","").
				        Replace("}", "").Replace(",","&").
			                Replace("\"", "");
			return str;
		}
