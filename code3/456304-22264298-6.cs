        ISite currentSite = ((MultisiteContext) SystemManager.CurrentContext).CurrentSite;
        using (var manager = PageManager.GetManager())
        {
            var nodes = manager.GetPageNodes().Where(p =>
                p.RootNodeId == currentSite.SiteMapRootNodeId &&
                p.NodeType == Telerik.Sitefinity.Pages.Model.NodeType.Standard &&
                p.ShowInNavigation);
            foreach (var node in nodes)
            {
                if (!node.Page.IsBackend &&
                    node.Page.Status == ContentLifecycleStatus.Live && 
                    node.Page.Visible)
                {
                    string host = getPageHost(serverPort, serverName, node.Page.RequireSsl);
                    var url = string.Concat(host, VirtualPathUtility.ToAbsolute(node.GetFullUrl()));
                    // Then append to sitemap
                }
            }
        }
