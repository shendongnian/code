    static void Main(string[] args)
    {
        string number = "731671...52963450";
        char[] numCharArray = number.ToCharArray();
        int maxProduct = 0; // initial value
       
        for (int i = 0; i < numCharArray.Length - 5 /* Fix IndexOutOfRange (see Matthew Fahrbach's answer) */; i++)
        {
            // ...
            int prod = iNum * n1 * n2 * n3 * n4;
            if (prod > maxProd)
            {
                maxProd = prod;
            }
        }
 
        Console.WriteLine(maxProd);
    }
