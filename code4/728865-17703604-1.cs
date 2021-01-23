    public class Movie
    {
       public bool RatingIsRequired { get; set; }
    
       [ConditionallyRequired("RatingIsRequired"]   
       public string Rating { get; set; }
    }
