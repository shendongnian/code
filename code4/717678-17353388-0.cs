    static string hundreds(Int64 n)
    {
        n %= 100;
        switch (n)
        {
        case 0:
            return "zero";
        case 10:
            return "ten";
        case 11:
            return "eleven";
        case 12:
            return "twelve";
        case 13:
            return "thirteen";
        case 14:
            return "fourteen";
        case 15:
            return "fifteen";
        case 16:
            return "sixteen";
        case 17:
            return "seventeen";
        case 18:
            return "eighteen";
        case 19:
            return "nineteen";
        }
        string s = "";
        switch (n / 10)
        {
        case 2:
            s = "twenty";
            break;
        case 3:
            s = "thirty";
            break;
        case 4:
            s = "fourty";
            break;
        case 5:
            s = "fifty";
            break;
        case 6:
            s = "sixty";
            break;
        case 7:
            s = "seventy";
            break;
        case 8:
            s = "eighty";
            break;
        case 9:
            s = "ninety";
            break;
        }
        if (n/10 > 0 && n%10 > 0)
            s += " ";
        switch (n % 10)
        {
        case 1:
            s += "one";
            break;
        case 2:
            s += "two";
            break;
        case 3:
            s += "three";
            break;
        case 4:
            s += "four";
            break;
        case 5:
            s += "five";
            break;
        case 6:
            s += "six";
            break;
        case 7:
            s += "seven";
            break;
        case 8:
            s += "eight";
            break;
        case 9:
            s += "nine";
            break;
        }
        return s;
    }
    static string thousands(Int64 n)
    {
        string s = "";
        int h = (int)(n%1000)/100;
        if (h > 0)
        {
            s += hundreds(h) + " hundred";
            int r = (int)n % 100;
            if (r == 0)
                return s;
            if (r > 0 && r < 10 && !string.IsNullOrEmpty(s))
                s += " and ";
            else if (!string.IsNullOrEmpty(s) && r > 0)
                s += " ";
        }
        return s + hundreds(n);
    }
    static string milionths(Int64 n)
    {
        string s = "";
        int t = (int)(n%10000000)/1000;
        if (t > 0 && t < 100)
        {
            s += hundreds(t) + " thousand";
        }
        else
        {
            t /= 100;
            if (t > 0)
                s += hundreds(t) + " lac";
        }
        int r = (int)n % 1000;
        if (r == 0)
            return s;
        if (r > 0 && r < 10 && !string.IsNullOrEmpty(s))
            s += " and ";
        else if (!string.IsNullOrEmpty(s) && r > 0)
            s += " ";
        return s + thousands(n);
    }
    static string crore(Int64 n)
    {
        string s = "";
        Int64 m = n/10000000;
        if (m > 0)
        {
            s += thousands(m) + " crore";
            int r = (int)n % 10000000;
            if (r == 0)
                return s;
            if (r > 0 && r < 10 && !string.IsNullOrEmpty(s))
                return s + " and one";
            else if (!string.IsNullOrEmpty(s) && r > 0)
                s += " ";
        }
        return s + milionths(n);
    }
    static void Main(string[] args)
    {
        System.Console.WriteLine(crore(9999));
        System.Console.WriteLine(crore(10000));
        System.Console.WriteLine(crore(10100));
        System.Console.WriteLine(crore(10101));
        System.Console.WriteLine(crore(99999));
        System.Console.WriteLine(crore(100000));
        System.Console.WriteLine(crore(100001));
        System.Console.WriteLine(crore(1000000));
        System.Console.WriteLine(crore(10000000));
        System.Console.WriteLine(crore(10000001));
        System.Console.ReadLine();
    }
