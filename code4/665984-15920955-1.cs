    static void Main(string[] args)
    {
        string str = "1234";
        char[] array = str.ToCharArray();
        string final = "";
        foreach (var i in array)
        {
            string hex = String.Format("{0:X}", Convert.ToInt32(i));
            final += hex.Insert(0, "0X") + " ";       
        }
        final = final.TrimEnd();
        Console.WriteLine(final);
    }
