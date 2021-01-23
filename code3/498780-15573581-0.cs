    // assign to null, since it will be "unassigned" otherwise
    RssItem rssItem = null;
    EventWaitHandle waithandle = new ManualResetEvent(false);
    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
    {
        rssItem = await m_RSSReader.CreateRSSItem(item.Links[0].Uri, m_CurrentRSSDataGroup, item, CurrentFeed);
        waithandle.Set();
    });
    waithandle.WaitOne();
    if (rssItem != null)
    {
        Debug.WriteLine("RssItem Title : {0}", rssItem.Title);
        m_RssItemList.Add(rssItem);
    }
