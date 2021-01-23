    public class RequestModel
    {
        public string FirstName { get; set; }
        ....
    }
    public ActionResult ContactForm(...)
    {
        var contactModel = new RequestModel();  
        if (User.IsInRole("Client"))
        {
            ...
        } 
        else if (User.IsInRole("Supplier"))
        {
            ...
        }
 
        return View(contactModel);
    }
