         public abstract class SynchronizedLoggedJob : IJob
        {
            private static readonly object _syncRoot = new object();
            
            protected abstract void JobExecute(IJobExecutionContext context);
    
            public void Execute(IJobExecutionContext context)
            {
                context.ThrowIfNull(nameof(context));
    			if (Convert.ToBoolean(context.JobDetail.JobDataMap["IsLocking"]))
    			{
    				lock (_syncRoot)
    				{
    					JobExecute(context);
    				}
    			}
    			else
    			{
    				JobExecute(context);
    			}
    		}
    }	
 
       
       <job>
          <name></name>
          <group></group>
          <description></description>
          <job-type></job-type>
          <!-- See, http://www.quartz-scheduler.org/documentation/quartz-2.x/tutorials/tutorial-lesson-03.html -->
          <durable>true</durable>
          <recover>false</recover>
          <job-data-map>
            <entry>
              <key>IsLocking</key>
              <value>True</value>
            </entry>
          </job-data-map>
        </job>
