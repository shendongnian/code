    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    internal class SomeSafeHandle : SafeHandle
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public SomeSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            return NativeMethods.FreeSomeState(this.handle) == 0;
        }
    }
