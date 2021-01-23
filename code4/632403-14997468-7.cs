    static void Main(string[] args)
    {
        var arg1 = 10;
        var arg2 = "abc";
        // create a Func with parameters in reversed order 
        Func<string, int, string> testStringInt = 
            MyFuncConverter<int, string, string>.ConvertFunction(TestIntString);
        var result1 = TestIntString(arg1, arg2);
        var result2 = testStringInt(arg2, arg1);
            
        // testing results
        Console.WriteLine(result1 == result2);
    }
    /// <summary>
    /// Sample method
    /// </summary>
    private static string TestIntString(int arg1, string arg2)
    {
        byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII
            .GetBytes(arg2.ToString() + arg1);
        string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
        return returnValue;
    }
