    // first you declare a poco to store only the needed properties.
    public class PhysicianViewModel {
        public string Password {get; set;}
        public string FirstName {get; set;}
    }
    // then you run your select query and drill down to grab
    // only the required data fields from the database
    var physicianViewModel = (from p in myDb.Physicians
                              where userAccounts.Phy_UserName == txtUserName.Text
                              select new PhysicianViewModel { 
                                  Password = p.Password,
                                  FirstName = p.Phy_FName }).FirstOrDefault();
    // and using them is the same as the above example
    // the only difference here is that the `physicianViewModel` doesn't 
    // contain ANY properties other than the ones you specified.
    var password = physicianViewModel.Password;
    var firstName = physicianViewModel.FirstName;
