     foreach (var eventList in ReadEvents())
         {
            // It seems this is what you want, only one event processed at a time by an "instance"? So block here until unlocked.
            LockProcess();
            var pluginIndex = 0;
            AsyncCallback handleResult = null;
            handleResult = delegate(IAsyncResult result)
            {
               if (pluginList[pluginIndex].EndReadAndExecuteEvents(result).Stop)
                  goto STOP;
               pluginIndex += 1;
               if (pluginIndex == pluginList.Count)
                  goto STOP;
               Events e = (Events)result.AsyncState;
               pluginList[pluginIndex].BeginReadAndExecuteEvents(e, handleResult, e);
               return;
            STOP:
               UnlockProcess();
            };
            pluginList[0].BeginReadAndExecuteEvents(eventList, handleResult, eventList);
         }
