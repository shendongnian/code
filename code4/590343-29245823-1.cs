    public class CpuAffinity
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentThread();
        [DllImport("kernel32.dll")]
        static extern IntPtr SetThreadAffinityMask(IntPtr hThread, IntPtr dwThreadAffinityMask);
        /// <summary>
        /// Sets the current Thread to have affinity to the specified cpu/processor if the system has more than one.
        /// 
        /// Supports most systems as we use a signed int; Anything more than 31 CPU's will not be supported.
        /// </summary>
        /// <param name="cpu">The index of CPU to set.</param>
        public static void SetCurrentThreadToHaveCpuAffinityFor(int cpu)
        {
            if (cpu < 0)
            {
                throw new ArgumentOutOfRangeException("cpu");
            }
            if (Environment.ProcessorCount > 1)
            {
                var ptr = GetCurrentThread();
                SetThreadAffinityMask(ptr, new IntPtr(1 << cpu));
                Debug.WriteLine("Current Thread Of OS Id '{0}' Affinity Set for CPU #{1}.", ptr, cpu);
            }else
            {
                Debug.WriteLine("The System only has one Processor.  It is impossible to set CPU affinity for other CPU's that do not exist.");
            }
        }
    }
