            int itemCount = ItemList.Count;
                 List<object> objectList = new List<object>();
                ManualResetEvent[] resetEvents = new ManualResetEvent[itemCount];
                for (int i = 0; i < itemCount; i++)
                {
                    var item= ItemList[i];
                    resetEvents[i] = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((object index) =>
                    {
                        ItemCalEvent item = getData(item);
                        lock (objectList)
                            objectList.Add(item);
                        resetEvents[(int)index].Set();
                    }), i);
                }
                WaitHandle.WaitAll(resetEvents);
