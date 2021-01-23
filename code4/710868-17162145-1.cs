    public class MyViewModel
    {
        public Language SelectedLanguage { get; set; }
        public IEnumerable<SelectListItem> Languages
        {
            get 
            {
                var languages = 
                    from l in Enum.GetValues(typeof(Language))
                    select new { ID = (int)d, Name = d.ToString() };
                return new SelectList(languages , "ID", "Name", this.SelectedLanguage);
            }
        }
    }
