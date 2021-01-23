    public class VendorRegistration : Hub
    {
        public void ReturnMembershipOptions(int vendorTypeId)
        {
            // get the options
            var options = AcoadRepo.Vendors.ApiLogic.MembershipOptions
                .ReturnOptions(vendorTypeId);
    
            // call the updateMembershipOptions method to update the client
            Clients.All.updateMembershipOptions(options);
        }
    }
