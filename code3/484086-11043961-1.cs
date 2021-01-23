    private void label2_Click(object sender, EventArgs e)
    {
        Process[] test = Process.GetProcessesByName("myprocess"); //Get process base address
        int Base = test[0].MainModule.BaseAddress.ToInt32(); // ""
        int Readpointer = ReadPointerInteger("myprocess", Base, new int[3] { 0xC, 0x5, 0x6 });
        string asciiString;
        unsafe
        {
            asciiString = new string((sbyte*)Readpointer);
        }
        // use asciiString
    }
