    public class SearchRoute {
       public string BeginAddress {get;set;}
       public string EndAddress {get;set;}
       public DateTime BeginDate {get;set;}
    }
    
    [HttpGet]
    public List<Route> Get([FromUri]SearchRoute sr)
    {
        return RouteDAO.GetAllByCity(sr);
    }
