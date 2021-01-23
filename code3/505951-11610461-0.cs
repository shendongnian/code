    public class BowlingGame
    {
       private List<double> _scores = new List<double>();
    
       public BowlingGame(IEnumerable<double> scores)
       {
           _scores.AddRange(scores);
       }
      
       public double Total
       {
           get { return _scores.Sum(); }
       }
    
       // implementation for SquareTotal and Mean
    }
