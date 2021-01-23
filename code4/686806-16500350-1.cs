    //Pass by value and return the values
    static Tuple<char, char> swap2(char a, char b)
    {
        char temp = a;
        a = b;
        b = temp;
        return new Tuple<char, char>(a, b);
    }
    
    //Pass by reference
    static void swap3(ref char a, ref char b)
    {
        char temp = a;
        a = b;
        b = temp;
    }
    public static void Main(string[] args)
    {
        char[] sw2 = "ab".ToCharArray();
        var chars2 = swap2(sw2[0], sw2[1]);
        sw2[0] = chars2.Item1;
        sw2[1] = chars2.Item2;
        //Will print "ba"
        Console.WriteLine(sw2);
    
        char[] sw3 = "ab".ToCharArray();
        swap3(ref sw3[0], ref sw3[1]);
        //Will print "ba"
        Console.WriteLine(sw3);
    }
