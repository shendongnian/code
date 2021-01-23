        public int QueuBuild(string TeamProject, string BuildDefinition)
        {
            IBuildServer buildServer = (IBuildServer)Server.GetService(typeof(IBuildServer));
            IBuildDefinition def = buildServer.GetBuildDefinition(TeamProject, BuildDefinition);
            
            var queuedBuild = buildServer.QueueBuild(def);
            return queuedBuild.Id;
        }
