    public class NullLogFactory : ILogFactory
    {
        SessionSettings settings_;
        #region LogFactory Members
        public NullLogFactory(SessionSettings settings)
        {}
        public ILog Create(SessionID sessionID)
        {
            return new QuickFix.NullLog();
        }
        #endregion
    }
