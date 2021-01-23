    public class SearchViewModel()
    {
        public int Distance { get; set; }
        public IEnumerable<SelectListItem> DistanceItems
        {
            get
            {
                List<int> distances = new List<int>() { 5, 15, 25, 50 };
                return distances.Select(d => new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }
        }
    }
