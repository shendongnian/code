    private static void ReportError(string Message)
    {
         StackFrame CallStack = new StackFrame(1, true);
         MessageBox.Show("Error: " + Message + ", File: " + CallStack.GetFileName() 
              + ", Line: " + CallStack.GetFileLineNumber());
    }
