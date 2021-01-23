    //Model
    public class CustomerViewModel
    {
        public Customer customer { get;set; }        
        public IEnumerable<Village> Villages { get; set; }
    }
    //Controller
    public ActionResult Index()
    {
        var customerViewModel = new CustomerViewModel
                               {
                                   Customer = new Customer(),
                                   Villages = _villageService.GetAll()
                               };
        return View(customerViewModel);
    }
    //View
    @model ViewModel.RegisterViewModel
    @Html.DropDownListFor(q => q.Customer.VillageId, new SelectList(Model.Villages, "Id", "Title"), "Please Select")
