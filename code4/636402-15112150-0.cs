    public class MyViewModel
    {
        public DateTime StartDate { get; set; }
    
        public string LocalizedStartDate
        {
            get
            {
                return this.StartDate.ToString(CultureInfo.CurrentUICulture);
            }
        }
    }
