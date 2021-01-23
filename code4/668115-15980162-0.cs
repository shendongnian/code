    public class TestSitesViewModel
    {
        //Eventually this will be added to a base ViewModel to get rid of
        //the ViewBag dependencies
        [Display(Name = "Web Page Title")]
        public string WebPageTitle { get; set; }
        //PUBLIC DATA MEMBER WON'T WORK
        //IT NEEDS TO BE PROPERTY AS DECLARED ABOVE
        //public string WebPageTitle;
        public IEnumerable<MVCWeb.MyEntities.Site> Sites;
        //Other Entities, IEnumberables, or properties go here
        //Not important for this example
    }
