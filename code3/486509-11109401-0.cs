    public ActionResult Download(string id) 
    { 
        var item = new CustomerPortalMVC.Models.Customer_Downloads(); 
        item.user_id = Membership.GetUser().ProviderUserKey.ToString(); 
        item.download_type = "Car"; 
        item.download_id = id; 
        item.download_date = DateTime.Now.ToString(); 
        item.user_ip_address = Request.ServerVariables["REMOTE_ADDR"];             
        dbcd.AddToCustomer_Downloads(item); 
        dbcd.SaveChanges(); 
        return Redirect("../../Content/files/" + id + ".EXE"); 
    } 
