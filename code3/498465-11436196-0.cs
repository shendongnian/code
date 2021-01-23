        public static void RunActions(
            IEnumerable<paramsActionSettings> listActions,
            IEnumerable<string> arrList,
            int numThreads,
            string domain = null,
            delGetParamsActionSettings delGetActionsList = null,
            delProcessString callbackActionsComplete = null)
        {
            var cntr = 0;
            var total = arrList.Count();
            var prlOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = numThreads
            };
            ////foreach (var listItemIter in arrList)
            Parallel.ForEach(arrList, prlOptions, listItemIter =>
            {
                Interlocked.Increment(ref cntr);
                Console.WriteLine("starting " + cntr + " of " + total + " run actions");
                var listItemCopySafe = string.Copy(listItemIter);
                var listActionsUse = listActions ??
                    ((delGetActionsList == null) ? new paramsActionSettings[0] : delGetActionsList());
                var canDo = listActionsUse.All(prms => prms.delCanDo == null
                    || prms.delCanDo(listItemCopySafe, domain));
                if (!canDo)
                {
                    return;
                }
                var listParams = listActionsUse.Select(prms => new paramsFire(
                    prms.delGetDoParams(listItemCopySafe),
                    prms.delDoSomething));
                // create a list of paramsfire objects, the object holds the params and the delfunction
                FireActions(listParams, callbackActionsComplete, listItemCopySafe);
                Console.WriteLine("Finished " + cntr + " of " + total);
            });
        }
        private static void FireActions(
            IEnumerable<paramsFire> list,
            delProcessString callbackActionsComplete,
            string itemArr)
        {
            var icntr = 0;
            foreach (var prms in list)
            {
                try
                {
                    if (icntr == 0)
                    {
                        if (!prms.delDoSomething(prms.oParams))
                        {
                            break;
                        }
                    }
                    else
                    {
                        prms.delDoSomething(prms.oParams);
                    }
                    icntr++;
                }
                catch (Exception e)
                {
                    ErrorLog.WriteLine("foreach (paramsFire prms in list)");
                    UtilException.Dump(e, "foreach (paramsFire prms in list)");
                }
            }
            if (callbackActionsComplete == null)
            {
                return;
            }
            try
            {
                callbackActionsComplete(itemArr);
            }
            catch
            {
            }
        }
