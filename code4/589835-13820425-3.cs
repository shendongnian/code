public class NavigationController : Controller
{
    public <strong>ActionResult</strong> Index(string CurrentPage)
    {
        PageType currentPageEnum = (PageType)Enum.Parse(typeof(PageType), CurrentPage);
        PageType nextPageEnum = currentPageEnum + 1;
        <strong>return RedirectToRoute</strong>(nextPageEnum.ToString());            
    }
}
