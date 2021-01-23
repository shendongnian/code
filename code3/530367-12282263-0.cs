    // from http://www.pinvoke.net/default.aspx/kernel32.readprocessmemory
    [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
    private static extern bool ReadProcessMemory(IntPtr Handle, IntPtr Address, 
        [Out] byte[] Arr, int Size, out int BytesRead);
    public static byte[] ReadBytes(IntPtr hnd, IntPtr Pointer, int Length)
    {
        byte[] Arr = new byte[Length];
        int Bytes = 0;
        if(!ReadProcessMemory(hnd, Pointer, Arr, Length, out Bytes)){
            // Throw exception ...
        }
        // Check if Bytes == Length ...
        return Arr;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        int[] valuesSeperated = new int[200];
        List<byte> PreArray = new List<byte>();
        //Get process handle
        Process[] test = Process.GetProcessesByName("notepad++");  
        //Get base address
        int baseAddress = test[0].MainModule.BaseAddress.ToInt32(); 
        byte[] ret = ReadBytes(test[0].Handle, new IntPtr(baseAddress), 10);
        // Interpret ret as you like ...
    }
