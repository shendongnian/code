        /// <summary>
        /// Generic method for performing an operation and tracking the time it takes to complete (returns a value)
        /// </summary>
        /// <typeparam name="T">Generic parameter which can be any Type</typeparam>
        /// <param name="actionText">Title for the log entry</param>
        /// <param name="func">The action (delegate method) to execute</param>
        /// <returns>The generic Type returned from the operation's execution</returns>
        
        public static T ExecuteTimedAction<T>(string actionText, Func<T> executeFunc, Action<string> logAction)
        {
            string beginText = string.Format("Begin Execute Timed Action: {0}", actionText);
            if (null != logAction)
            {
                logAction(beginText);
            }
            else
            {
                LogUtil.Log(beginText);
            }
            Stopwatch stopWatch = Stopwatch.StartNew();
            T t = executeFunc(); // Execute the action
            stopWatch.Stop();
            string endText = string.Format("End Execute Timed Action: {0}", actionText);
            string durationText = string.Format("Total Execution Time (for {0}): {1}", actionText, stopWatch.Elapsed);
            if (null != logAction)
            {
                logAction(endText);
                logAction(durationText);                
            }
            else
            {
                LogUtil.Log(endText);
                LogUtil.Log(durationText);
            }
            return t;
        }
