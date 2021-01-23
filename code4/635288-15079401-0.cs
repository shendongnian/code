    string s = "30d";
    int typeIndex = s.IndexOfAny(new char[] { 'd', 'm' }); // TODO: Add other indicators
    if (typeIndex > 0)
    {
        int value = int.Parse(s.Substring(0, typeIndex));
        switch (s[typeIndex])
        {
            case 'd':
                // Add days
                result = DateTime.Now.AddDays(value);
                break;
            case 'm':
                // Add months
                result = DateTime.Now.AddMonths(value);
                break;
        }
    }
