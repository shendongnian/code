        public ActionResult Index(PagedClientViewModel model)
        {
            var pageIndex = model.Page ?? 1;
            var clients = from client in GetAllClients() orderby client.CLIENTNUMBER
                          select new ClientViewModel
                              {
                                  ClientName = client.CLIENTNAME,
                                  ClientNumber = client.CLIENTNO
                              };        
            model.Clients = clients.ToPagedList(pageIndex, 25);
            return View(model);
        }
    public class PagedClientViewModel
    {
        public int? Page { get; set; }
        public PagedList.IPagedList<ClientViewModel> Clients { get; set; }
    }
    public class ClientViewModel
    {
        public string ClientNumber { get; set; }
        public string ClientName { get; set; }       
    }
