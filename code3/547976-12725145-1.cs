    CancellationTokenSource cts = new CancellationTokenSource(); 
    ParallelOptions options = new ParallelOptions 
                                 {CancellationToken = cts.Token}; 
    Parallel.ForEach(
                    webnode.ChildNodes.OfType<XmlNode>(),
                     options 
                    (node,loopState) =>
                        {
                            if(threadCommand!=null &&                   threadCommand.CurrentSubIndicator.StopSignaled)
                                cts.Cancel();
                            string title = node.Attributes["Title"].Value;
                            string url = node.Attributes["Url"].Value;
                            if (!string.IsNullOrEmpty(specificItemUrl) &&
                                (!url.Equals(specificItemUrl)))
                                return;
                            cts.Token.ThrowIfCancellationRequested();
                            Site partialSubSite = new WSS(site, Guid.Empty, title, url, "", null, null);
                            try
                            {
                                GetSite(partialSubSite, lite, readNavigation);
                            }
                            catch (Exception ex)
                            {
                                LogERError("Failed to fully read sub-site: {0}", url, ex);
                                partialSubSite.Guid = Constants.BadItemId;
                            }
                        });
