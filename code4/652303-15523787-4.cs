    public class EditSeasonViewModel
    {
        public List<SelectListItem> Clubs { set;get;}
        public int SelectedClub { set;get;}
        public string PlayerName {get; set;}
        public string SummaryText {get; set;}
        public int PlayerId {get; set;}
        public Season season {get; set;}
        public EditSeasonViewModel()
        {
            Clubs=new List<SelectListItem>();
        }
    }
