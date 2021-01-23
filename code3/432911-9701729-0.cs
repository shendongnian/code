    var sqlLogger = (Logger)LogManager.GetRepository().GetLogger("NHibernate.SQL");
    _sqlappender = new NhSqlAppender();
    sqlLogger.AddAppender(_sqlappender);
    if (!sqlLogger.IsEnabledFor(Level.Debug))
        sqlLogger.Level = Level.Debug;
    class NhSqlAppender : AppenderSkeleton
    {
        private List<string> queries = new List<string>(1000);
        public IList<string> Queries
        {
            get { return queries; }
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            queries.Add(loggingEvent.RenderedMessage);
        }
    }
