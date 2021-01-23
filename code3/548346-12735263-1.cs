    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/
        public ActionResult Index()
        {
            IList<OrganizationDTO> list = new List<OrganizationDTO>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new OrganizationDTO { orgID = i, orgName = "Org " + i });
            }
            return View(list);
        }
    }
