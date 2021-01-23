    static void Main(string[] args)
    {
     try
     {
      Console.Write("Please Enter the Year: ");
      int year = int.Parse(Console.ReadLine());
      if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
          {
            Console.WriteLine("The year {0}, is a Leap Year", year);
           }
          else
           {
            Console.WriteLine("The year {0}, is not a Leap Year", year);
          }
      }
        catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
      Console.ReadLine(); 
    }
