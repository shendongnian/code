    using System;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Client;
    
    namespace BuildDetails
    {
        class Program
        {
            static void Main()
            {
                TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://tfsURI"));
                var buildService = (IBuildServer)teamProjectCollection.GetService(typeof(IBuildServer));
    
                IBuildDefinition buildDefinition = buildService.GetBuildDefinition("TeamProjectName", "BuildDefinitionName");
                IBuildDetail[] buildDetails = buildService.QueryBuilds(buildDefinition);
    
                foreach (var buildDetail in buildDetails)
                {
                    IBuildInformation buildInformation = buildDetail.Information;
                    Console.Write(buildDetail.BuildNumber+"\t");
                    Console.Write(buildDefinition.Name+"\t");
                    Console.Write(buildDetail.Status+"\t");
                    Console.Write(buildDetail.StartTime+"\t");
                    Console.WriteLine((buildDetail.FinishTime - buildDetail.StartTime).Minutes);
                }
            }
        }
    }
