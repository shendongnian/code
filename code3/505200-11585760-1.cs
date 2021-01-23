    public class DomainsDto
    {
        public int DomainMasterId { get; set; }       // this does bind
        public string DisplayName  { get; set; }      // this does bind
        public List<DomainDto> Domains { get; set; }  // this does not bind
        public DomainsDto()
        {
    
        }
    }
