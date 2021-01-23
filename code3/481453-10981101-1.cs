    public class ReadTfsRevisionTask : Task
    {
        public override bool Execute()
        {
            try
            {
                ChangesetId = GetLatestChangeSet(Server, Project);
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        private int GetLatestChangeSet(string url, string project)
        {
            project = string.Format(@"$/{0}", project);
    
            var server = new TeamFoundationServer(new Uri(url));
            var version = server.GetService<VersionControlServer>();
    
            var workspace = version.QueryWorkspaces(null, WindowsIdentity.GetCurrent().Name, System.Environment.MachineName).First();
            var folder = workspace.Folders.First(f => f.ServerItem == project);
    
            return workspace.GetLocalVersions(new[] { new ItemSpec(folder.LocalItem, RecursionType.Full) }, false)
                .SelectMany(lv => lv.Select(l => l.Version)).Max();
        }
    
        [Required]
        public string Server { get; set; }
    
        [Required]
        public string Project { get; set; }
    
        [Output]
        public int ChangesetId { get; set; }
    
    }
