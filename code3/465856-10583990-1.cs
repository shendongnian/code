        public string GetBuildStatus(string TeamProject, string BuildDefinition, int BuildID)
        {
            IBuildServer buildServer = (IBuildServer)Server.GetService(typeof(IBuildServer));
            string status = string.Empty;
            IQueuedBuildSpec qbSpec = buildServer.CreateBuildQueueSpec(TeamProject, BuildDefinition);
            
            IQueuedBuildQueryResult qbResults = buildServer.QueryQueuedBuilds(qbSpec);
            if(qbResults.QueuedBuilds.Length > 0)
            {
                IQueuedBuild build = qbResults.QueuedBuilds.Where(x => x.Id == BuildID).FirstOrDefault();
                status = build.Status.ToString();
            }
            return status;
        }
