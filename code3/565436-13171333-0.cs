    const string space = "  ";
    static string StrMultiplier(string str,int multiplier)
    {
	    return string.Concat(Enumerable.Repeat(str,multiplier).ToArray());
    }
    static int F(int a,int level = 0)
    {
        Console.WriteLine("{0}->F({1})",StrMultiplier(space,level),a);//Trace line
        if (a == 1)
            return 1;
        else if (a == 0)
            return 0;
        else
            return F(a-2,level + 1) + F(a-1,level+1);
    }
