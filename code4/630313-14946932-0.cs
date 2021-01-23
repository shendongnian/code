    public class MyViewModel
    {
        [Required]
        public string SelectedHuman { get; set; }
        public IEnumerable<SelectListItem> AllHumans { get; set; }
    }
