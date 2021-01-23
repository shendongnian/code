    public class LoginCredential
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
    }
    public ActionResult Index()
    {
        ViewBag.Organizations = new SelectList(db.Organizations, "OrgID", "OrgName");
        return View();
    }
