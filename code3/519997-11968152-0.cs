    public partial class Test
    {
        Test()
        {
           //some code
        }
    }
    public partial class Test
    {
        private IList<SelectListItem> _days = new List<SelectListItem>();
        public IList<SelectListItem> days {
            get { return _days; }
            set { _days = value; }
        }
    }
