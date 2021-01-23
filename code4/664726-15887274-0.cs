    static void Main(string[] args)
    {
        string test = "";
        int intNumber = 1;
    
        string value = "2a2b";
        char[] array = value.ToArray();
        int count = 1;
    
        while (count < array.Length)
        {
            int num;
            if (array[count] != default(char))
            {
                bool isNumeric = int.TryParse(array[count].ToString(), out num);
                if (!isNumeric)
                {
    
                    test = test + new string(array[count], intNumber);
                    test = test + array[count];
    
                    Console.WriteLine(test);
    
                    intNumber = 1;
                }
                else
                {
                    intNumber = num;
    
                }
            }
            count++;
        }
        Console.WriteLine("woord:" + test);
    
    
        Console.ReadLine();
    }
