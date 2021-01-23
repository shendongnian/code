     var timersDict = new Dictionary<string, Timers>();
     var items = GetDownloadList();
     int CountDownloadListItems = DownloadItemsCount();
    for (int i = 0; i < CountDownloadListItems; i++)
                    {
                        if (ClassLib.UrlExists.Check(items[i, 2], items[i, 0]))
                        {
                            //new instance of timers
                            Timers downloadTimer = new Timers();
                            downloadTimer.CreateTimer(items[i, 2], items[i, 3], items[i, 4], items[i, 0], items[i, 5], items[i, 6]);
                            timersDict.Add("Timer" + i, downloadTimer);
                        }
                    }
