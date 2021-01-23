    public class NumberRank
    {
       public int Number {get; set;}
       public int Rank {get; set;}
    
       public NumberRank(int number, int rank)
       {
          Number = number;
          Rank = rank;
       }
    }
    
    class Test
    {
       static void Main()
       {
          List<int> numbers = new List<int>();
    
          numbers.Add(650);
          numbers.Add(150);
          numbers.Add(500);
          numbers.Add(200);
    
          List<NumberRank> numberRanks = numbers.OrderByDescending(n => n).Select((n, i) => new NumberRank(n, i + 1)).ToList();
    
          // check it worked
          foreach(NumberRank nr in numberRanks) Console.WriteLine("{0} : {1}", nr.Rank, nr.Number);
          Console.ReadKey();  
       }
    }
