    [Test]
    void TestFiles()
    {
        using(var process = Process.Start("app.exe"))
        {
            Thread.Sleep(1000);
            process.Kill();
            process.WaitForExit();
        }
        // Check your files now
    }
