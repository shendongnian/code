    public static void Main(I cannot remember what goes here!)
    {
        string s = Console.ReadLine();
        int n = Convert.ToInt32(s);
        int[] arprimes = GeneratePrimes(n);
        string output = "";
        for (i=0; i<arprimes.Length;i++)
        {
            output += arprimes[i].ToString() + ", ";
        }
        output = output.Remove(output.Length - 3, 2);
        Console.WriteLine(output);
    }
