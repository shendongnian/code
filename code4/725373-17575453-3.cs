    public string IntToString(int a, int radix)
    {
        var chars = "0123456789ABCDEF".ToArray();
        var str = new char[32]; // maximum number of chars in any base
        var i = str.Length;
        bool isNegative = (a < 0);
        if (a <= 0) // handles 0 and int.MinValue special cases
        {
            str[--i] = chars[-(a % radix)];
            a = -(a / 10);
        }
        
        while (a != 0)
        {
            str[--i] = chars[a % radix];
            a /= radix;
        }
    
        if (isNegative)
        {
            str[--i] = '-';
        }
   
        return new string(str.Skip(i).ToArray());
    }
