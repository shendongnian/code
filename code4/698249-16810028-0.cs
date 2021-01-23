    class Scope : IDisposable
    {
        Action<string> _logger;
        string _memberName;
    
        public Scope(Action<string> logger, [CallerMemberName] string memberName = "N/A")
        {
            if (logger == null) throw new ArgumentNullException();
    
            _logger = logger;
            _memberName = memberName;
    
            _logger(string.Format("Entered {0}", _memberName));
        }
    
        public void Dispose()
        {
            _logger(string.Format("Exited {0}", _memberName));
        }
    }
