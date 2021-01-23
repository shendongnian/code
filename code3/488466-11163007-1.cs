    void Main()
    {
        const String CollectionAddress = "http://tfsserver:8080/tfs/MyCollection";
        const String ProjectName = "MyProject";
    
        using (var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
            new Uri(CollectionAddress)))
        {
            tfs.EnsureAuthenticated();
            var server = tfs.GetService<ICommonStructureService>();
    
            var projectInfo = server.GetProjectFromName(ProjectName);
            var nodes = server.ListStructures(projectInfo.Uri).Dump();
    
            // You should be able to re-factor this with "Iteration"
            // for getting those too.
            var nodesXml = server.GetNodesXml(
                nodes
                    .Where(node => node.Name == "Area")
                    .Select(node => node.Uri).ToArray(),
                true);
    
            var areaPathAndId =
                XElement.Parse(nodesXml.OuterXml)
                .Descendants("Node")
                .Select(xe => new 
                { 
                    Path = xe.Attribute("Path").Value, 
                    ID = xe.Attribute("NodeID").Value, 
                })
                .Dump();        
        }
    }
