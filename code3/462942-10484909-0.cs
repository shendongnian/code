    public class ViewModelClass
    {
        public string DomainName { get; set; }
    
        public IEnumerable<SelectListItem> DomainList
        {
            get
            {
                return GetDomainNames()  //your method to get domain names
                 .Select(d => new SelectListItem() { Text = d, Value = d });
            }
        }
    }
