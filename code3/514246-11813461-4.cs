    public class StoreManagerController : Controller
    {
        private MusicStoreDBEntities context = new MusicStoreDBEntities();  
        public ActionResult Index()
        {
            AlbumsCollection albumsCollection = new AlbumsCollection();
            albumsCollection.Albums = context.Albums;
            
            return View(albumsCollection);
        }
    }
