    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    namespace WorkItemLinksOfAWorkItem
    {
        class Program
        {
            static void Main()
            {
                TfsTeamProjectCollection teamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://TFSURI"));
    
                var workItemStore = (WorkItemStore)teamProjectCollection.GetService(typeof(WorkItemStore));
    
                var workItem = workItemStore.GetWorkItem(123456);
                LinkCollection links = workItem.Links;
                foreach (Link link in links)
                {
                    if (!(link is RelatedLink))
                        continue;
    
                    var relLink = link as RelatedLink;
                    var relatedWI = workItemStore.GetWorkItem(relLink.RelatedWorkItemId);
                    Console.WriteLine(relatedWI.Id+" "+relatedWI.Type.Name);
                }
            }
        }
    }
