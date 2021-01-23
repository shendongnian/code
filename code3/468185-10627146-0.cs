    public class IssuesController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult List(string projectName, int issueCount = 0)
        {
            IEnumerable<Issue> issueList = new List<Issue>();
            // Here load appropriate issues into issueList
            return PartialView(issueList);
        }
    }
