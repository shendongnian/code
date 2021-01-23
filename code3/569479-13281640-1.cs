    private void RunAX1Program(string text)
    {
        ManualResetEvent resetEvent = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(RunAX1ProgramDelegate,
            new object[] { resetEvent, text });
    }
    private void RunAX1ProgramDelegate(object state)
    {
        object[] stateArray = (object[])state;
        ManualResetEvent resetEvent = (ManualResetEvent)stateArray[0];
        string text = (string)stateArray[1];
        Program program = new Program();
        program.AX1Program(this, resetEvent, text);
        //Wait until the event is signalled from AX1Program.
        resetEvent.WaitOne();
    }
