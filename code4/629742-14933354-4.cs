     public abstract class BackgroundTask
    {
        protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected virtual void Initialize()
        {
        }
        protected virtual void OnError(Exception e)
        {
           //do some work
        }
        public bool? Run()
        {
            Logger.Info("Started task: {0}", GetType().Name);
            Initialize();
            try
            {
                Execute();
                TaskExecuter.StartExecuting();
                return true;
            }
            catch (Exception e)
            {
                Logger.ErrorException("Could not execute task " + GetType().Name, e);
                OnError(e);
                return false;
            }
            finally
            {
                TaskExecuter.Discard();
                Logger.Info("Finished task: {0}", GetType().Name);
            }
        }
        public abstract void Execute();
    }
