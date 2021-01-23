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
        //Get process handle
        Process[] test = Process.GetProcessesByName("notepad++");  
        //Get base address
        IntPtr baseAddress = test[0].MainModule.BaseAddress; 
        int bytesToRead = 16;
        int[] valuesSeparated = new int[bytesToRead / 4];
        byte[] ret = ReadBytes(test[0].Handle, baseAddress, bytesToRead);
        // Interpret ret as you like ...
        // Convert ret to int[]
        valuesSeparated = ....
    }
