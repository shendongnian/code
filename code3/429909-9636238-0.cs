    public partial class DatabaseEntities
    {
        partial void OnContextCreated()
        {
            Subsection.MergeOption = MergeOption.OverwriteChanges;
            Section.MergeOption = MergeOption.OverwriteChanges;
            Function.MergeOption = MergeOption.OverwriteChanges;
        }
    }
