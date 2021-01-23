    static void LargestPalindrome()
    {
        ulong product = 0;
        ulong compare = 0;
        List<ulong> results = new List<ulong>();
        for (uint i = 100; i < 1000; i++) 
        {
            for (uint j = 100; j < 1000; j++)
            {
                product = i * j;
                StringBuilder value = new StringBuilder(product.ToString());
                //Pass string to reverse
                string value_r = Reverse(value.ToString());
                //Check if Numeric Palindrome
                if(value_r.Equals(value.ToString()) && product>compare)
                {      
                    results.Add(product);
                }
            }
        }
        results.Sort();
        foreach (var palindrome in results)
        {
            Console.WriteLine(palindrome);
        }    
    }
