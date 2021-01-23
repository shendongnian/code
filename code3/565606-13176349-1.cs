    public class QueueLog
    {
         [ManyToOne (Fetch = FetchType.EAGER, TargetEntity = typeof(Question))]
         [JoinColumn(Name = "question_id")]
         public virtual Question question { get; set; }
    }
