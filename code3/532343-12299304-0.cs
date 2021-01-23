    using log4net;
    Class YourClassName
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(YourClassName));
        public void DoWork()
        {
            try
            {
                 //Your code goes here [written in your question]
            }
            catch(Exception e)
            {
                _log.Fatal(e);
            }
        }
    }
