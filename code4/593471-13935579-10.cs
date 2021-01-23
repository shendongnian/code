    private delegate void DelegateSendMsg(String msg);
    private DelegateSendMsg m_DelegateSendMsg;
    private TaskScheduler uiSched;
    private Process thisProcess;
    private string
        thisProcessName,
        thisProcessId,
        uiThreadName,
        nonuiStatus = "Non-UI",
        uiStatus = "UI";
    
    private void Form1_Load(object sender, EventArgs e)
    {
        thisProcess = Process.GetCurrentProcess();
        thisProcessName = thisProcess.ProcessName;
        thisProcessId = thisProcess.Id.ToString();
        uiThreadName = CurrentThread;
        m_DelegateSendMsg = this.SendMsg;
        uiSched = TaskScheduler.FromCurrentSynchronizationContext();
        SendMsg("UI thread name is " + CurrentThread);
    }
    
    //create the name of the current task
    public string CurrentThread
    {
        get
        {
            string threadId = null;
            if (String.IsNullOrEmpty(Thread.CurrentThread.Name))
                threadId = thisProcess.Id.ToString() + "=" + thisProcessName;
            else
                threadId = thisProcessId
                    + "=" + thisProcessName
                    + "/" + Thread.CurrentThread.Name;
            threadId += ":" + Thread.CurrentThread.ManagedThreadId + " ";
            return threadId;
        }
    }
    
    //validate if the function is running in the expected UI state or not
    public bool MeetsUIExpectations(string functionName, string expectedStatus)
    {
        bool rc = true;
        string currentThreadName = CurrentThread;
        string text = 
            "Function " + functionName + " running in thread " + currentThreadName;
        if ((currentThreadName == uiThreadName) & expectedStatus == uiStatus)
            text += ": UI status as expected";
        else if ((currentThreadName != uiThreadName) & expectedStatus == nonuiStatus)
            text += ": non-UI status as expected";
        else
        {
            text += ": UI status is NOT as expected!"
                + "  Expected: " + expectedStatus
                + "; running in thread" + currentThreadName;
            rc = false;
        }
        SendMsg(text);
        return rc;
    }
    
    //display a single text message
    private void SendMsg(String msg)
    {   
        if (this.InvokeRequired)
            try { this.Invoke(m_DelegateSendMsg, "UI context switch: " + msg); }
            catch (Exception) { }
        else
        {
            listBox1.Items.Add(msg);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew<bool>((a) =>
            T1(), TaskScheduler.Default,
                TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent)
            .ContinueWith(antecedent => T1Completed(antecedent.Result), uiSched);
    }
    
    private bool T1()
    {
        //get the name of the currently running function and validate UI status
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), nonuiStatus);
    
        int i = 0;
        while (i < Int32.MaxValue) i++;
        return true;
    }
    
    private void T1Completed(bool successful)
    {
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), uiStatus);
        if (successful)
        {
            Task.Factory.StartNew<bool>((a) =>
                T2(), TaskScheduler.Default,
                    TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent)
                .ContinueWith(antecedent => T2Completed(antecedent.Result), uiSched);
        }
    }
    
    private bool T2()
    {
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), nonuiStatus);
        int i = 0;
        while (i < Int32.MaxValue) i++;
        return true;
    }
    
    private void T2Completed(bool successful)
    {
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), uiStatus);
        Task.Factory.StartNew<bool>((a) =>
            T3(), TaskScheduler.Default,
                TaskCreationOptions.LongRunning | TaskCreationOptions.AttachedToParent)
            .ContinueWith(antecedent => T3Completed(antecedent.Result), uiSched);
    }
    
    private bool T3()
    {
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), nonuiStatus);
        int i = 0;
        while (i < Int32.MaxValue) i++;
        return true;
    }
    
    private void T3Completed(bool successful)
    {
        //get the name of the currently running function and validate UI status
        var currentMethod = System.Reflection.MethodInfo.GetCurrentMethod();
        MeetsUIExpectations(currentMethod.ToString(), uiStatus);
        SendMsg("All functions completed");
    }
