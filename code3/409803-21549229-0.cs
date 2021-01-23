        private ILog GetLogger(){
            var tn = this.GetType().FullName;
            if (!_loggers.ContainsKey(tn)) {
                _loggers.Add(tn,LogManager.GetLogger(this.GetType()));
            }
            return _loggers[tn];
        }
