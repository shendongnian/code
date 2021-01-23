    // Example view model containing data for Info and pagenumberResults needed on the view
    // Replace MyInfo with the type of object your info variable is.
    public class MyViewModel
    {
       public MyInfo Info { get; set; }
       public PageNumberResults Pages { get; set; }
    }
    public ViewResult Index(string Ordering, int? CounterForPage)
        {
            var FullDatabaseItem = from b in db.tblGames
                                   select b;
            var Info = db.tblGames.Include(x => x.tblConsole).Where(UserInfo => UserInfo.UserName.Equals(User.Identity.Name)).ToList();
            
            switch (Ordering)
            {
                case "HeadlineName":
                    FullDatabaseItem = FullDatabaseItem.OrderBy(b => b.GameName);
                    break;
                case "DatePosted":
                    FullDatabaseItem = FullDatabaseItem.OrderBy(b => b.ReleaseYear);
                    break;
                case "DiscriptionDate":
                    FullDatabaseItem = FullDatabaseItem.OrderBy(b => b.ReleaseYear);
                    break;
                default:
                    FullDatabaseItem = FullDatabaseItem.OrderByDescending(b => b.ReleaseYear);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (CounterForPage ?? 1);
            var PageNumberResults = FullDatabaseItem.ToPagedList(pageNumber, pageSize);
            if (PageNumberResults.Any())
            {
                return View(new MyViewModel()
                           {
                               Info = info,
                               PageNumberResults = FullDatabaseItem.Count()
                            });
            }
            return View("ErrorView");
        }
