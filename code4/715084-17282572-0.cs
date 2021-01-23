    double kv = 0;
    bool invalid = false;
    do
    {
       console.writeline("Enter your value");       
       try
       {
          kv = Convert.ToDouble(Console.ReadLine());
       }
       catch (FormatException)
       { invalid = true;}
    } while (invalid);
