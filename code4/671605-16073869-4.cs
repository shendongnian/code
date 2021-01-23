    public class ContractViewModel {
        // start:read-only fields. 
        // These are the fields that will be used as read-only
        public string product_name { get; set; }
        public string adv_product { get; set; }
        public IEnumerable<SelectListItem> PrintAdOptions { get; set; }
        // end:read-only fields.
        public InputModel Contract {get;set;}    
    }
    // you use this class to capture "all your inputs"
    public class InputModel {
        public int contract_id {get;set;}
        public string contract_name { get; set; }
        public IEnumerable<InputSubModel> ads {get;set;}
    }    
    public class InputSubModel {
        public int contr_ad_id {get;set;}
        public string print_ad_option_id {get;set;} // is this really a string?
        public string name {get;set;}
    }
