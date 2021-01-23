    public class VenueController : MasterController
    {
        [Dependency]
        public ISuppliersRepository _SuppliersRepository { get; set; }
    }
    public class AjaxController : Controller
    {
        [Dependency]
        public IBaseRepository _BaseRepository { get; set; }
    }
