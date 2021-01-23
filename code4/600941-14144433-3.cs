    public class ValidateViewModel
    {
        public int[] Mdays { get; set; }
        public IEnumerable<string> AvailableMonths { get; set; }
        public IEnumerable<string> AvailableYears { get; set; }
        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }
        public bool CanShowChart { get; set; }
        
        public List<SelectListItem> GetMonthsSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
        
            foreach(var month in AvailableMonths)
            {
                bool selected = month == SelectedMonth;
                list.Add(new SelectListItem() { Text = month, Value = month, Selected = selected });
            }
        
            return list;
        }
    
        public List<SelectListItem> GetYearsSelectList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
        
            foreach(var year in AvailableYears)
            {
                bool selected = month == SelectedYear;
                list.Add(new SelectListItem() { Text = year, Value = year, Selected = selected });
            }
        
            return list;
        }
    
    }
