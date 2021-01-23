    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint Ret1ArgDelegate(uint arg1);
    public static void Main(string[] args){
        // Bitwise rotate input and return it.
        // The rest is just to handle CDECL calling convention.
        byte[] asmBytes = new byte[]
        {        
          0x55,             // push ebp
          0x8B, 0xEC,       // mov ebp, esp 
          0x8B, 0x45, 0x08, // mov eax, [ebp+8]
          0xD1, 0xC8,       // ror eax, 1
          0x5D,             // pop ebp 
          0xC3              // ret
        };
        
        // Allocate memory with EXECUTE_READWRITE permissions
    	IntPtr executableMemory = 
            VirtualAlloc(
                IntPtr.Zero, 
                (UIntPtr) asmBytes.Length,    
                AllocationType.COMMIT,
                MemoryProtection.EXECUTE_READWRITE
            );
        // Copy the machine code into the allocated memory
    	Marshal.Copy(asmBytes, 0, executableMemory, asmBytes.Length);
        // Create a delegate to the machine code.
        Ret1ArgDelegate del = 
            (Ret1ArgDelegate) Marshal.GetDelegateForFunctionPointer(
                executableMemory, 
                typeof(Ret1ArgDelegate)
            );
	
        // Call it
        uint n = (uint)0xFFFFFFFC;
        n = del(n);
        Console.WriteLine("{0:x}", n);
        // Free the memory
        VirtualFree(executableMemory, UIntPtr.Zero, FreeType.DECOMMIT);
     }
