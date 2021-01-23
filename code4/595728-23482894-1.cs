    objExplorerService = (ObjectExplorerService)ServiceCache.ServiceProvider.GetService(typeof(IObjectExplorerService));
                        //cs = (ContextService)objExplorerService.Container.Components[0];
                        //cs.ObjectExplorerContext.CurrentContextChanged += new NodesChangedEventHandler(ObjectExplorerContext_CurrentContextChanged);
                        // cs.UtilityExplorerContext.CurrentContextChanged += new NodesChangedEventHandler(UtilityExplorerContext_CurrentContextChanged);
    
                        int count = objExplorerService.Container.Components.Count;
    
                        int nodeCount; INodeInformation[] nodes;
    
                        objExplorerService.GetSelectedNodes(out nodeCount, out nodes);
                        count = nodeCount; count = nodes.Length;
                        count = objExplorerService.Container.Components.Count;
                        ContextService contextService;
                        try
                        {
                             contextService = (ContextService)objExplorerService.Container.Components[1];
                        }
                        catch (Exception ex)
                        {
                            using (StreamWriter w = File.AppendText("c:\\temp\\log.txt"))
                            {
                                Log(ex.Message, w);
                                Log("Failed Adding Event ", w);
                            }
                            contextService = (ContextService)objExplorerService.Container.Components[0];
    
                        }
                        INavigationContextProvider provider = contextService.ObjectExplorerContext;
                        provider.CurrentContextChanged += new NodesChangedEventHandler(ObjectExplorerContext_CurrentContextChanged);
