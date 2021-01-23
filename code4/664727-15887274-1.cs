    static void Main(string[] args)
    {
        string test = "";
        int intNumber = 1;
    
        string value = "2a2b";
    
        foreach (char c in value.ToArray())
        {
            int num;
            bool isNumeric = int.TryParse(c.ToString(), out num);
            
            if (!isNumeric)
            {
                test = test + new string(c, intNumber);
            
                Console.WriteLine(test);
            
                intNumber = 1;
            }
            else
            {
                intNumber = num;
            }
        }
    
        Console.WriteLine("woord:" + test);
        Console.ReadLine();
    }
