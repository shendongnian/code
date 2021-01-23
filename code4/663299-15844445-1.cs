    public class RealtyViewModel 
    { 
        /// Gets or sets the id. /// public int Id { get; set; }
    
        public string Address { get; set; }
    
        /// <summary>
        /// Gets the details.
        /// </summary>
        public string Details { get; get; }
        public List<HomeViewModel> Homes { get; set; }
        
        /// <summary>
        /// Gets the manager.
        /// </summary>
    
        public IEnumerable<SelectListItem> Managers { get; set; }
        
        public ManagerViewModel Manager { get; set; }
        public RealtyViewModel(int id,string Address, string Details, ManagerViewModel Manager)
        {
            this.Id = id;
            this.Address = Address;
            this.Details = Details;
            this.Manager = Manager;
        }
        
        public RealtyViewModel() {}
    }
