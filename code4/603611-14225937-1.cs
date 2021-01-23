    ...
        public Logger(string logname)
        {
             log = logname;
             writer = new StreamWriter(log);
        }
        StreamWriter writer = null;
    ...
