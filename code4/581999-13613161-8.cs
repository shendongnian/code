		private static readonly Dictionary<string, string> ColorMap = new Dictionary<string, string>(){
			{"Greenlike", "Green"},
			{"Reddish", "Red"},
		};
    public string FormatColor(string color)
		{
			if (string.IsNullOrWhiteSpace(color)) return null;
			if (ColorMap.ContainsKey(color))
				return ColorMap[color];
			return color;
		}
