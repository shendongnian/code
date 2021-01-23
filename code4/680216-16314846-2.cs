    int total = 0;
    using(inFile = new StreamReader("text.txt"))
    {
        while ((inValue = inFile.ReadLine()) != null)
        {   
            if(Int32.TryParse(inValue, out number))
            {
                 total += number;
                 Console.WriteLine("{0}", number);
            }
            else
                Console.WriteLine("{0} - not a number", inValue);
        }
    }
    Console.WriteLine("The sum is  {0}", total);
