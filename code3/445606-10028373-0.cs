    public class AjaxController : Controller
    {
            [Dependency]
            public IRepository _BaseRepository { get; set; }
    }
