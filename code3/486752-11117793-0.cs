    class Foo
    {
	public string Month { get; set; }
	public int Day { get; set; }
	public int Hour { get; set; }
	public int Minute { get; set; }
	public int Second { get; set; }
	public string Login { get; set; }
	public string Rest { get; set; }
    }
    string strRegex = @"(?<Month>[A-Z]{3})\s(?<Day>[0-9]{1,2})\s(?<Hour>[0-9]{1,2}):(?<Minute>[0-9]{1,2}):(?<Second>[0-9]{1,2})\s<(?<Login>[^>]+)>(?<Rest>.*)";
    RegexOptions myRegexOptions = RegexOptions.None;
    Regex myRegex = new Regex(strRegex, myRegexOptions);
    string strTargetString = @"JAN 01 00:00:01 <Admin> Action, May have spaces etc. \n";
    foreach (Match myMatch in myRegex.Matches(strTargetString))
    {
        if (myMatch.Success)
        {
            new Foo
            {
                Month = myMatch.Groups["Month"].Value,
                Day = Convert.ToInt32(myMatch.Groups["Day"].Value),
                Hour = Convert.ToInt32(myMatch.Groups["Hour"].Value),
                Minute = Convert.ToInt32(myMatch.Groups["Minute"].Value),
                Second = Convert.ToInt32(myMatch.Groups["Second"].Value),
                Login = myMatch.Groups["Login"].Value,
                Rest = myMatch.Groups["Rest"].Value
            }
        }
    }
