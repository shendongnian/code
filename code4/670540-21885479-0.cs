    public static bool SetStyle(Control c, ControlStyles Style, bool value)
	{
	    bool retval = false;
	    Type typeTB = typeof(Control);
	    System.Reflection.MethodInfo misSetStyle = typeTB.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
	    if (misSetStyle != null && c != null) { misSetStyle.Invoke(c, new object[] { Style, value }); retval = true; }
	    return retval;
	}
