    public static String ParseData(String data)
    {
        MatchCollection matches = Regex.Matches(data, "0[xX]([a-fA-F0-9]{2})");
        Int32 count = 0;
        String result = String.Empty;
        foreach (Match match in matches)
        {
            switch (count)
            {
                case 0:
                {
                    if (match.Value == "1E")
                    {
                        result += "S";
                        break;
                    }
                    goto End;
                }
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    result += match.Groups[1].Value;
                    break;
                case 6:
                    result += Int32.Parse(match.Groups[1].Value, NumberStyles.HexNumber).ToString();
                    count = -1;
                    break;
            }
            ++count;
        }
        End:;
        return result;
    }
