    public ScheduledTaskHandler(IScheduledTaskManager taskManager,ILoggerFactory LoggerFactory, IMyService myService)
        {
            _myService = myService;
            _taskManager = taskManager;
            Logger = NLoggerFactory.CreateLogger(typeof(ScheduledTaskHandler));;
            try
            {
                DateTime firstDate = new DateTime().AddMinutes(5);
                ScheduleNextTask(firstDate);
            }
            catch (Exception e)
            {
                this.Logger.Error(e, e.Message);
            }
        }
