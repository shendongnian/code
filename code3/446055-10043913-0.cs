    public static class lgr
    {
	#region "log4Net"
	private static bool _isInfoEnabled = false;
	private static bool _isWarnEnabled = false;
	private static bool _isDebugEnabled = false;
	private static ILog _logger;
	public static ILog Logger {
		get {
			if ((_logger == null)) {
				_logger = LogManager.GetLogger("root");
				_isInfoEnabled = _logger.IsInfoEnabled;
				_isWarnEnabled = _logger.IsWarnEnabled;
				_isDebugEnabled = _logger.IsDebugEnabled;
			}
			return _logger;
		}
		set {
			if ((value == null)) {
				_logger = LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod.DeclaringType);
			} else {
				_logger = value;
			}
		}
	}
	public static string LoggerName {
		get { return Logger.Logger.Name; }
		set {
			if (value == null || value == string.Empty) {
				Logger = null;
			} else {
				Logger = LogManager.GetLogger(value);
			}
		}
	}
	public enum LogType
	{
		Debug,
		Info,
		Warn,
		Error_,
		Fatal
	}
	public static void WriteLogError(string _message, Exception ex)
	{
		if (Logger.IsErrorEnabled) {
			Logger.Error(_message, ex);
		}
	}
	public static void WriteLogInfo(string _message)
	{
		if (_isInfoEnabled) {
			Logger.Info(_message);
		}
	}
	public static void WriteLogWarn(string _message)
	{
		if (_isWarnEnabled) {
			Logger.Warn(_message);
		}
	}
	#endregion
