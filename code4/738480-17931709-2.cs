    public static List<int> ForEachCharManualParse(string s, char delim)
    {
        List<int> result = new List<int>();
        int tmp = 0;
        foreach(char x in s)
        {
            if(x == delim)
            {
                result.Add(tmp);
                tmp = 0;
            } 
            else if (x >= '0' && x <= '9')
            {
                tmp = tmp * 10 + x - '0';
            }
            else
            {
                throw new ArgumentException("Invalid input: " + s);
            }
        }
        result.Add(tmp);
        return result;
    }
