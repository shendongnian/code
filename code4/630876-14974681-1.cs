    public class ConflictAMapping : ClassMap<Conflict<Issue>>
    {
        public ConflictAMapping()
        {
            Id(c => c.Id).GeneratedBy.Assigned();
            Map(c => c.DateOfConflict);
            Map(c => c.Comment);
            HasMany(c => c.RelatedConflicts)
                .KeyColumn("RelatedToConflict")
                .Cascade.All();
            References(c => c.OriginalEntity)
                .EntityName("ArchivedIssue")
                .Column("FK_Issue_id")
                .Cascade.All();
        }
    }
    public class IssueMapping : ClassMap<Issue>
    {
        public IssueMapping()
        {
            Id(c => c.Id).GeneratedBy.Assigned();
            Map(c => c.Key);
            Map(c => c.Created);
            HasMany(g => g.Conflicts)
                .KeyColumn("IssueKey")
                .PropertyRef("Key")
                .Cascade.None();
        }
    }
    public class ArchivedIssueMapping : IssueMapping
    {
        public ArchivedIssueMapping()
        {
            Table("ArchivedIssues");
            EntityName("ArchivedIssue");
        }
    }
