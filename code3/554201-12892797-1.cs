    using (Process process = Process.Start("notepad.exe"))
    {
        process.WaitForInputIdle();
        Console.WriteLine(process.Id);
    }
