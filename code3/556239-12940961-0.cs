    try
    {
    	int a = 10;
    	int b = 0;
    	litDebug.Text = (a / b).ToString();
    }
    catch (Exception ex)
    {
    	StackTrace st = new StackTrace(ex, true);
    	StackFrame sf = st.GetFrame(0);
    	litDebug.Text = "" +
    		"<br />File Name: " + sf.GetFileName() +
    		"<br />Method Name: " + sf.GetMethod().Name +
    		"<br />Error Line Number: " + sf.GetFileLineNumber() +
    		"<br />Error Column Number: " + sf.GetFileColumnNumber();
    }
