        public static ConcurrentDictionary<string, myRule> ccDict= new ConcurrentDictionary<string, myRule>();
           try
            {
                while (ccDict.Count > 0)
                {
                    Parallel.ForEach(ccDict, pOptions, (KVP, loopState) =>
                    {
                        //This is the flag that tells the loop do exit out of loop if a cancellation has been requested
                        pOptions.CancellationToken.ThrowIfCancellationRequested();
                        processRule(KVP.Key, KVP.Value, loopState);
                    }); //End of Parallel.ForEach loop
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();
            }
        public static int processRule(string rId, myRule rule, ParallelLoopState loopState)
        {
            try
            {
                if (rId == "001" || rId == "002")
                {
                    if (rId == "001" && ccDict[rId].RetryAttempts == 2)
                    {
                        operationPassed(rId);
                        return 0;
                    }
                    operationFailed(rId);
                }
                else
                {
                    operationPassed(rId);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed : " + ex.Message.ToString());
                return -99;
            }
        }
        private static void operationPassed(string rId)
        {
            //Normal Operation
            ccDict[rId].RulePassed = true;
            ccDict[rId].ExceptionMessage = "";
            ccDict[rId].ReturnCode = 0;
            Console.WriteLine("passed: " + rId + " Retry Attempts : " + ccDict[rId].RetryAttempts.ToString());
            rule value;
            ccDict.TryRemove(rId, out value);
        }
        private static void operationFailed(string ruleId)
        {
            //This acts as if an EXCEPTION has OCCURED
            int retryCount = 0;
                ccDict[rId].RulePassed = false;
                ccDict[rId].RetryAttempts = ccDict[rId].RetryAttempts + 1;
                ccDict[rId].ExceptionMessage = "Forced Fail";
                ccDict[rId].ReturnCode = -99;
                ccDict.TryUpdate(rId, ccDict[rId], ccDict[rId]);
                if (ccDict[rId].RetryAttempts >= 5)
                {
                    Console.WriteLine("Failed: " + rId + " Retry Attempts : " + ccDict[rId].RetryAttempts.ToString() + " : " + ccDict[rId].ExceptionMessage.ToString());
                    cancelToken.Cancel();
                }
        }
        public class myRule
        {
            public Boolean RulePassed = true;
            public string ExceptionMessage = "";
            public int RetryAttempts = 0;
            public int ReturnCode = 0;
            public myRule()
            {
                RulePassed = false;
                ExceptionMessage = "";
                RetryAttempts = 0;
                ReturnCode = 0;
            }
        }
