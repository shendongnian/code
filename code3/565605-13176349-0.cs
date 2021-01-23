    public class Question
    {
       [OneToMany(TargetEntity = typeof(QueueLog), MappedBy = "question", Fetch = FetchType.EAGER, Cascade = new CascadeType[] { CascadeType.ALL })]
       public virtual NHibernate.Collection.PersistentBag QueueLogs { get; set; }
    }
