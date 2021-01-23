    class Issue
    {
        public virtual int Id { get; protected set; }
        public virtual string Key { get; set; }   // same for all versions of the issue
        public virtual DateTime Created { get; set; }
    }
    class Conflict<T>
    {
        public virtual Guid Id { get; protected set; }
        public virtual T OriginalEntity { get; set; }
        public virtual DateTime DateOfConflict { get; set; }
        public virtual string Comment { get; set; }
        public virtual string IssueKey { get; set; }
        public virtual ICollection<Conflict<T>> RelatedConflicts { get; protected set; }
    }
