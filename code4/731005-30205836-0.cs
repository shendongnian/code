    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            ActionsList = new List<SelectListItem>();
        }
        public IEnumerable<SelectListItem> ActionsList { get; set; }
        public string StudentGrade { get; set; }
      }
