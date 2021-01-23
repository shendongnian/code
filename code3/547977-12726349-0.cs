     Parallel.ForEach(
                        webnode.ChildNodes.OfType<XmlNode>(),
                       (node, loopState) =>
                        {
                            if (threadCommand != null && threadCommand.CurrentSubIndicator.StopSignaled)
                                loopState.Stop();
                            
                            string title = node.Attributes["Title"].Value;
                            string url = node.Attributes["Url"].Value;
                            if (!string.IsNullOrEmpty(specificItemUrl) &&
                                (!url.Equals(specificItemUrl)))
                                return;
                            if (loopState.IsStopped)
                                loopState.Break();
                            Site partialSubSite = new WSS(site, Guid.Empty, title, url, "", null, null);
                            try
                            {
                                if (loopState.IsStopped)
                                    loopState.Break();
                                GetSite(partialSubSite, lite, readNavigation);
                            }
                            catch (Exception ex)
                            {
                                LogERError("Failed to fully read sub-site: {0}", url, ex);
                                partialSubSite.Guid = Constants.BadItemId;
                            }
                            if (partialSubSite.Web.IsBucketWeb)
                            {
                                lock (others)
                                    others.AddRange(partialSubSite.Web.SubWebUrls.Cast<string>());
                                return;
                            }
                            lock (subSites)
                                subSites.Add(partialSubSite as WSS);
                        });
