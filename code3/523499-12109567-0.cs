    public class PickUpLocationViewModel 
    {
        public DateTime PuDate { get; set }
    
        public IAddressViewModel Address { get; set; }
    }
    public class AirportAddressViewModel: IAddressViewModel
    {
        public string Terminal { get; set; }
    }
    public class SeaportAddressViewModel: IAddressViewModel
    {
        public int DockNumber { get; set; }
    }
