    public class ConnectionViewModel
    {
        public string AuthenticationType { get; set; }
        public string ConnectionString { get; set; }
        ...
    }
    public ActionResult Login()
    {
        // pass in defaults 
        return View(new ConnectionViewModel
        {
            AuthenticationType = "Windows",
            ConnectionString = "..."
        });
    }
    [HttpPost]
    public ActionResult Login(ConnectionViewModel viewModel)
    {
        // pass view model back into view to retain values
        return View(viewModel);
    }
