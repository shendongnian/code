        public sealed class CreateDatabaseDrop : CodeActivity
        {
            [RequiredArgument]
            public InArgument<Workspace> Workspace { get; set; }
            [RequiredArgument]
            public InArgument<IBuildDefinition> BuildDefinition { get; set; }
            [RequiredArgument]
            public InArgument<string> ProjectName { get; set; }
            Workspace workspace;
    
            protected override void Execute(CodeActivityContext context)
            {
                workspace = context.GetValue(this.Workspace);
                IBuildDefinition buildDef = context.GetValue(this.BuildDefinition);
                DateTime? comparison = null;
                var details = buildDef.QueryBuilds().Where(x => x.Status == BuildStatus.Succeeded).OrderBy(x => x.StartTime);
                if (details.Count() > 0)
                {
                    comparison = details.Last().StartTime;
                }
                if (!comparison.HasValue)
                {
                    return;
                }
                IEnumerable history = workspace.VersionControlServer.QueryHistory("$/" + context.GetValue(ProjectName),
                    VersionSpec.Latest,
                    0,
                    RecursionType.Full,
                    null,
                    new DateVersionSpec(comparison.Value),
                    VersionSpec.Latest,
                    Int32.MaxValue,
                    true,
                    false);
    
                foreach (Changeset c in history.OfType<Changeset>().OrderBy(x => x.CreationDate))
                {
                    foreach (var change in c.Changes.Where(x => x.Item.ItemType == ItemType.File
                        && x.Item.ServerItem.Split('/').Last().ToLower().Contains(".sql")
                        && (x.ChangeType != (ChangeType.Delete | ChangeType.SourceRename | ChangeType.Rename))))
                    {
                        string fileName = change.Item.ServerItem.Split('/').Last();
                        WorkingFolder wf = workspace.TryGetWorkingFolderForServerItem(change.Item.ServerItem);
                        if (wf != null && !string.IsNullOrEmpty(wf.LocalItem))
                        {
                            context.WriteBuildMessage(string.Format("SQL File found: {0}", fileName));
                        
                        }
                    }
                }
        }
