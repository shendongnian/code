    using System.Diagnostics;
    using System.Threading;
    [Test]
    public void logtest()
    {
        // ...
        Process proc = Process.Start(@"c:\windows\system32\notepad.exe");
        if ( null == proc )
            Assert.Fail("Could not start process, maybe an existing process has been reused?");
        Thread.Sleep(50000);
        proc.Kill();
        // ...
    }
