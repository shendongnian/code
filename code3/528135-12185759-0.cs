    var trace = new StackTrace(true);
    var frame = trace.GetFrame(0);  // current frame
    var lineNumber = frame.GetFileLineNumber();
    var method = frame.GetMethod().Name;
    var className = frame.GetMethod().ReflectedType.Name;
