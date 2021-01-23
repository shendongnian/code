        /// <summary>
        /// evaulates if a custom log level is enabled. 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static bool IsLevelEnabled(this log4net.ILog log, log4net.Core.Level level)
        {
            var hierarchy = log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
            if (hierarchy != null)
            {
                var appenders = hierarchy.GetAppenders();
                foreach (log4net.Appender.IAppender appender in appenders)
                {
                    var appenderSkeleton = appender as log4net.Appender.AppenderSkeleton;
                    if (appenderSkeleton != null)
                    {
                        log4net.Filter.IFilter filterHead = appenderSkeleton.FilterHead;
                        //traverse the filter chain
                        var currentFilter = filterHead;
                        while (currentFilter.Next != null)
                        {
                            if (currentFilter is log4net.Filter.LevelMatchFilter)
                            {
                                //if the filter level matches the target
                                if (((log4net.Filter.LevelMatchFilter)currentFilter).LevelToMatch == level)
                                {
                                    return true;
                                }
                            }
                            //move to the next filter
                            currentFilter = currentFilter.Next;
                        }
                    }
                }
            }
            return false;
        }
