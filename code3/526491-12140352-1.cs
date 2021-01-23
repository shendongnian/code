    public class MyModel
    {
        [BeforeEndDate(EndDatePropertyName = "EndDate", StartDate = "2000/01/01")]
        public DateTime StartDate { get; set; }
        // [AfterStartDate(StartDatePropertyName = "StartDate", EndDate = "2020/01/01")]
        public DateTime EndDate { get; set; }
    }
