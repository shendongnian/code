    public class HomeIndexViewModel
    {
        public SearchViewModel SearchViewModels { get; set; } // same thing as below.
    
        [Required(ErrorMessage="Please enter feedback summary")]
        public string FeedBackModelstrSummary  { get; set; }
        [Required(ErrorMessage = "Please enter feedback details")]
        public string FeedBackModelstrDetail  { get; set; }
    }
