    using System.Numerics;
    
    void Main()
    {
    	int x = Convert.ToInt32(Console.ReadLine());
    
    	BigInteger  p = new BigInteger(1);
    	for (int i = 1; i <= x; i++)
    	{
    			p = p * i;
    	}
    	Console.WriteLine(p);
    	Console.ReadLine();
    }
