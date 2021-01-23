    System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("osk");
    if (proc.Length > 0)
    {
        this.Activate();
        textBox1.Focus(); //i focused it so i can write in it using on-screen keyboard
    }
