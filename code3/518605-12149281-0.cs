    @model SampleDropDown.Models.CustomerData
   
    using (Html.BeginForm("Continue", "Customer"))
    {
        if (Model.Customers != null)
        {
    @Html.DropDownListFor(m => m.SelectedCustomerId, new SelectList(Model.Customers, "CustomerId", "DisplayText"))
    
        }
    
    <input type="submit" value="Select" />
    }
    public class CustomerData
       {
        public List<Customer> Customers { get; set; }
        public string SelectedCustomerId { get; set; }
        public string Response { get; set; }
        }
     public class Customer
        {
        public string DisplayText { get; set; }
        public string CustomerId { get; set; }
       }
