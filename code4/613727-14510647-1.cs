    public class Roads
    {
       private List<CrossStreets> _crossStreets = new List<CrossStreets>();
       public string RoadName { get; set; }
       public List<CrossStreet> CrossStreets { get { return _crossStreets;} }        
    }
    
    public class CrossStreet
    {
       public string CrossStreetName { get; set;}
    }
