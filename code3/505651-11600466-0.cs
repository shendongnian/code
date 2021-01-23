    [DllImport("Kernel32")]
    public static extern void AllocConsole();
    [DllImport("Kernel32")]
    public static extern void FreeConsole();
    private void button1_Click(object sender, EventArgs e)
    {
        AllocConsole();
        Console.WriteLine("test");
    }
