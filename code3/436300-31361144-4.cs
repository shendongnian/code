    [DllImport("kernel32.dll", EntryPoint = "CreateJobObjectW", CharSet = CharSet.Unicode)]
    public static extern IntPtr CreateJobObject(SecurityAttributes JobAttributes, string lpName);
    
    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);
    
    [DllImport("kernel32.dll")]
    static extern bool SetInformationJobObject(IntPtr hJob, JOBOBJECTINFOCLASS JobObjectInfoClass, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);
    
    public class SecurityAttributes
    {
    
        public int nLength; 
        public IntPtr pSecurityDescriptor; 
        public bool bInheritHandle;
    
        public SecurityAttributes()
        {
            this.bInheritHandle = true;
            this.nLength = 0;
            this.pSecurityDescriptor = IntPtr.Zero;
        }
    }
    
    public enum JOBOBJECTINFOCLASS
    {
        JobObjectAssociateCompletionPortInformation = 7,
        JobObjectBasicLimitInformation = 2,
        JobObjectBasicUIRestrictions = 4,
        JobObjectEndOfJobTimeInformation = 6,
        JobObjectExtendedLimitInformation = 9,
        JobObjectSecurityLimitInformation = 5,
        JobObjectCpuRateControlInformation = 15
    }
    
    [StructLayout(LayoutKind.Explicit)]
    //[CLSCompliant(false)]
    struct JOBOBJECT_CPU_RATE_CONTROL_INFORMATION
    {
        [FieldOffset(0)]
        public UInt32 ControlFlags;
        [FieldOffset(4)]
        public UInt32 CpuRate;
        [FieldOffset(4)]
        public UInt32 Weight;
    }
    
    public enum CpuFlags
    {
        JOB_OBJECT_CPU_RATE_CONTROL_ENABLE = 0x00000001,
        JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED = 0x00000002,
        JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP = 0x00000004
    }
    
    /// <summary>
    /// Launch the legacy application with some options set.
    /// </summary>
    static void DoExecuteProgramm()
    {
        // prepare the process to execute
        var startInfo = new ProcessStartInfo();
        . . . . . 
        // Start the process
        var process = Process.Start(startInfo);
    
        //Limit the CPU usage to 45%
        var jobHandle = CreateJobObject(null, null);
        AssignProcessToJobObject(jobHandle, process.Handle);
        var cpuLimits = new JOBOBJECT_CPU_RATE_CONTROL_INFORMATION();
        cpuLimits.ControlFlags = (UInt32)(CpuFlags.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE | CpuFlags.JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP);
        cpuLimits.CpuRate = 45 * 100; // Limit CPu usage to 45%
        var pointerToJobCpuLimits = Marshal.AllocHGlobal(Marshal.SizeOf(cpuLimits));
        Marshal.StructureToPtr(cpuLimits, pointerToJobCpuLimits, false);
        if (!SetInformationJobObject(jobHandle, JOBOBJECTINFOCLASS.JobObjectCpuRateControlInformation, pointerToJobCpuLimits, (uint)Marshal.SizeOf(cpuLimits)))
        {
            Console.WriteLine("Error !");
        }
    }
