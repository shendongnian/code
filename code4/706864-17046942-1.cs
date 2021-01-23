    public class CourseOffering
    {
        public Guid CourseOfferingId { get; set; }
        public String DayOfWeek { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Guid StaffId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual Staff Staff { get; set; }
    }
