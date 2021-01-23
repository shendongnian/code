           TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                new Uri("http://<server>:8080/tfs/<collection>"));
            WorkItemStore wiStore = tpc.GetService<WorkItemStore>();
            VersionControlServer vc = tpc.GetService<VersionControlServer>();
            WorkItem task = wiStore.GetWorkItem(<work item with a linked file>);
            var externalLinks = task.Links.OfType<ExternalLink>();
            foreach (var link in externalLinks)
            {
                XmlDocument artifact = vc.ArtifactProvider.GetArtifactDocument(new Uri(link.LinkedArtifactUri));
            }
