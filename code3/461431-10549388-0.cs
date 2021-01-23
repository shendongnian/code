    public class PrivateLesson : RecurringLesson
    {
        public string Student { get; set; }
        public string Teacher { get; set; }
        //public virtual ICollection<Cancellation> Cancellations { get; set; }
    }
    
    public class Cancellation
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        //public virtual PrivateLesson Lesson { get; set; }
        //public virtual MakeUpLesson MakeUpLesson { get; set; }
    }
    
    public class MakeUpLesson : Lesson
    {
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        //public virtual Cancellation Cancellation { get; set; }
    }
