        static void ScheduleTaskTrigger()
        {
            HttpRuntime.Cache.Add("ScheduledTaskTrigger",
                                  string.Empty, 
                                  null, 
                                  Cache.NoAbsoluteExpiration, 
                                  TimeSpan.FromMinutes(60), // Every 1 hour
                                  CacheItemPriority.NotRemovable, 
                                  new CacheItemRemovedCallback(PerformScheduledTasks));
        } 
        static void PerformScheduledTasks(string key, Object value, CacheItemRemovedReason reason)
        {
           //Your TODO
           ScheduleTaskTrigger();
        }
        void Application_Start(object sender, EventArgs e)
        {
              ScheduleTaskTrigger();
        }
