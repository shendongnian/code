    Process newProcess= new Process();  
    newProcess.StartInfo.FileName = "YourProcessPath+FileName.exe" //use CombinePath  
    newProcess.StartInfo.Arguments = string.Format("{0}", Process.GetCurrentProcess().Id);  
    var handle = new EventWaitHandle(false, EventResetMode.AutoReset, Process.GetCurrentProcess().Id.ToString());
    handle.Reset();
    handle.WaitOne(); //wait until event is Set() from child Process
