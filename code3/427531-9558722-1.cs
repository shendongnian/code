    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint Ret1ArgDelegate(uint arg1);
    public static void Main(string[] args){
        byte[] asmBytes = new byte[]
        {        
          0x55,             // push ebp
          0x8B, 0xEC,       // mov ebp, esp 
          0x8B, 0x45, 0x08, // mov eax, [ebp+8]
          0xD1, 0xC8,       // ror eax, 1
          0x5D,             // pop ebp 
          0xC3              // ret
        };
        
    	IntPtr executableMemory = VirtualAlloc(IntPtr.Zero, (UIntPtr) asmBytes.Length, AllocationType.COMMIT, MemoryProtection.EXECUTE_READWRITE);
    	Marshal.Copy(asmBytes, 0, executableMemory, asmBytes.Length);
        Ret1ArgDelegate del = (Ret1ArgDelegate) Marshal.GetDelegateForFunctionPointer (executableMemory, typeof(Ret1ArgDelegate));
	
        uint n = (uint)0xFFFFFFFC;
        n = del(n);
        Console.WriteLine("{0:x}", n);
        VirtualFree(executableMemory, UIntPtr.Zero, FreeType.DECOMMIT);
     }
