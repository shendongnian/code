    public class Distance
    {
    int Source {get;set;}
    int Destination{get;set;}
    int Value{ 
              get{ return Math.Abs(Destination - Source);}
             }
    }
    
