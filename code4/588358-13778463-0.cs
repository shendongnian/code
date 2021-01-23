    public class Audit : IAudit
    {
        public IEnumerable<ICategory> Categories { get; set; }
        public IEnumerable<IAuditAnswer> Answers { get; set; }
    }
