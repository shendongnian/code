    //Get parent window.
    AutomationElement element = AutomationElement.FromHandle(Win32.FindWindow(null, "Form1"));
    //Get all descendants
    AutomationElementCollection elements =  element.FindAll(TreeScope.Descendants, Condition.TrueCondition);
    //loop through descendants
	foreach (AutomationElement elementNode in elements)
	{
        //if descendant is a progress bar
		if (elementNode.Current.NativeWindowHandle != 0 && elementNode.Current.LocalizedControlType == "progress bar")
		{
			//Show value of the bar.
			MessageBox.Show(Win32.SendMessage((IntPtr)elementNode.Current.NativeWindowHandle, Win32.PBM_GETPOS, IntPtr.Zero, IntPtr.Zero).ToString(), "Bar value");
		}
	}
