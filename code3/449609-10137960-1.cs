    public class AddressController : BaseController
    {
        public ActionResult List()
        {
            var addressList = blObject.GetAddressList();
            var model = new AddressListViewModel();
            model.AddressList = addressList.Select(a => 
                new AddressViewModel 
                {
                    Country = a.Country.Name,
                    City = a.City,
                    Street = a.Street,
                    CanDelete = ...check user access here...,
                    CanEdit = ...check user access here...
                });
            model.CanAdd = ...check user access here...
            return View(model);
        }
    }
