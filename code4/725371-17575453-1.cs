    public string IntToString(int a)
    {    
        var chars = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        var str = string.Empty;
        if (a == 0)
        {
            str = chars[0];
        }
        else if (a == int.MinValue)
        {
            str = "-2147483648";
        }
        else
        {
            bool isNegative = (a < 0);
            if (isNegative)
            {
                a = -a;
            }
            while (a > 0)
            {
                str = chars[a % 10] + str;
                a /= 10;
            }
            if (isNegative)
            {
                str = "-" + str;
            }
        }
        return str;
    }
