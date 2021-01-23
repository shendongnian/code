    public class WorkerInfo
    {
        // I don't know exact type of fields, but its enough for you to get the idea
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Enter { get; set; }
        public DateTime ExitT { get; set; }
        public string Place { get; set; }
        public int WorkTime
        {
           get { return (ExitT - Enter).TotalDays; }
        }
        public decimal Earned
        {
           get { return WorkTime * Salary; }
        }
    }
