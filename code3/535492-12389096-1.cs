    public class HomeController : Controller
    {
        public ActionResult Index(string search)
        {
            using (var client = new WebClient())
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["q"] = search;
                var json = client.DownloadString("http://gd.geobytes.com/AutoCompleteCity?" + query.ToString());
                var serializer = new JavaScriptSerializer();
                var viewModel = serializer
                    .Deserialize<string[]>(json)
                    .Select((x, index) => new CityViewModel
                    {
                        Id = index,
                        Name = x
                    })
                    .Where(x => x.Name.StartsWith(search ?? string.Empty, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_IndexGrid", viewModel);
                }
                else
                {
                    return View(viewModel);
                }
            }
        }
    }
