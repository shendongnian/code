    public class ClientController : StandardController
    {
        public ActionResult Edit(long id = 0)
        {
            return base.Edit<Client>(id);
        }
    }
