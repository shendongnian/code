    public class LocationViewModel
    {
         public int StateId { get; set; }
    
         public IEnumerable<State> States { get; set; }
    
         public int DistrictId { get; set; }
    
         public IEnumerable<District> Districts { get; set; }
    }
