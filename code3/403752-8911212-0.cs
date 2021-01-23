    using (Process process = Process.Start(@"D:\abc.txt"))
    {
        int pid = process.Id;
        // Whether you want for it to exit, depends on your needs. Your
        // Interaction.Shell() call above suggests you don't.  But then
        // you need to be aware that "pid" might not be valid when you
        // you look at it, because the process may already be gone.
        // A problem that would also arise with Interaction.Shell.
        // process.WaitForExit();
    }
