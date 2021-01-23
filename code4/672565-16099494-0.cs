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
    List<int> numbers = new List();
    
    numbers.Add(650);
    numbers.Add(150);
    numbers.Add(500);
    numbers.Add(200);
    numbers.OrderBy(n => n)
           .Select((n, index) => new NumberRank(n, index));
