    public class CrossFieldValidation
    {
        [ValueMustbeInRange]
        public string DDlList1
        { get; set; }
        /* add the items list into the model */
        public IEnumerable<SelectListItem> Items 
        { get; set; }    
        public string SelectedValue
        { get; set; }
    
        [Display(Name = "Quantity:")]
        public string TxtCrossField
        { get; set; }
    }
