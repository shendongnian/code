	string myString = "violet are blue|roses are red|this is a terrible poet";
    var elements = myString.Split(new char[] { '|' }).Skip(1);
	
	StringBuilder sb = new StringBuilder();
	foreach (var element in elements)
	{
		sb.Append(element);
		sb.Append("|");
	}
	
	string result = sb.Remove(sb.Length - 1, 1).ToString();
	
	Console.WriteLine(result);
