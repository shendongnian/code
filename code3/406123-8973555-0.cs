    List<string> cities = new List<string>();
    foreach (DataRow row in dt.Rows)
    {
		string city = row[0].ToString();
        cities.Add(String.Concat(Regex.Replace(city, "([a-zA-Z])([a-zA-Z]+)", "$1").ToUpper(System.Globalization.CultureInfo.InvariantCulture), Regex.Replace(city, "([a-zA-Z])([a-zA-Z]+)", "$2").ToLower(System.Globalization.CultureInfo.InvariantCulture)));
    }
    return cities;
