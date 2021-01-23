    int itemCount = listItem.Length;
    List<object> objectList = new List<object>();
    ManualResetEvent[] resetEvents = new ManualResetEvent[itemCount];
    for (int i = 0; i < itemCount; i++)
    {
        var item = listItem[i];
	
        resetEvents[i] = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(new WaitCallback((object index) =>
        {
            object obj = getData(item);
            lock (objectList)
                objectList.add(obj);
			
            resetEvents[(int)index].Set();
        }), i);
    }
    WaitHandle.WaitAll(resetEvents);
    Console.Write("Finish all");
