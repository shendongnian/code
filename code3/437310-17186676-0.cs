    static void Main(string[] args)
    {
        // Test pattern
        args = new string[] { "-flag1", "value1", "-flag2", "value2", "-flag3", "value3" };
        if (args.Length == 0)
            MainWinApp();
        else
            MainCLI(args);
            
    }
    [STAThread]
    static MainWinApp()
    {
        // Your code for start GUI application
    }
    [STAThreadAttribute]
    static void MainCLI(string[] args)
    {
        // Your code for CLI application
    }
