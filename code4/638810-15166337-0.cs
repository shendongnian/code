    [Serializable]
    public sealed class AuditInfo
    {
        public AuditInfo()
        {
            SetCreated(string.Empty, DateTime.Now);
        }
        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string RevisedBy { get; private set; }
        public DateTime RevisedDate { get; private set; }
        public string CreatedInfo
        {
            get { return "Created: " + CreatedDate.ToShortDateString() + " by " + CreatedBy; }
        }
        public string RevisedInfo
        {
            get { return "Revised: " + RevisedDate.ToShortDateString() + " by " + RevisedBy; }
        }
        internal void SetCreated(string createdBy, DateTime createdDate)
        {
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            SetRevised(createdBy, createdDate);
        }
        internal void SetRevised(string revisedBy, DateTime revisedDate)
        {
            RevisedBy = revisedBy;
            RevisedDate = revisedDate;
        }
    }
