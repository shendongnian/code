    struct PROCESSOR_POWER_POLICY_INFO
        {
            public uint TimeCheck;
            public uint DemoteLimit;
            public uint PromoteLimit;
            public byte DemotePercent;
            public byte PromotePercent;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Spare;
            public uint AllowBits;
        }
        struct PROCESSOR_POWER_POLICY
        {
            public uint Revision;
            public byte DynamicThrottle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Spare;
            public uint Reserved;
            public uint PolicyCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public PROCESSOR_POWER_POLICY_INFO[] Policy;
        }
        struct MACHINE_PROCESSOR_POWER_POLICY
        {
            public uint Revision;                   // ULONG
            public PROCESSOR_POWER_POLICY ProcessorPolicyAc;
            public PROCESSOR_POWER_POLICY ProcessorPolicyDc;
        }
        [DllImport("powrprof.dll", SetLastError = true)]
        static extern bool ReadProcessorPwrScheme(uint uiID, out MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);
        public void ReadProcessorPowerScheme()
        {
            MACHINE_PROCESSOR_POWER_POLICY machinep = new MACHINE_PROCESSOR_POWER_POLICY();
            uint scheme = 0;
            if (ReadProcessorPwrScheme(scheme, out machinep))
            {
                //Then loop through machinep.ProcessorPolicyAc.Policy[]; array
                //Use:  PROCESSOR_POWER_POLICY_INFO processorPolicyInfoAc = mppp.ProcessorPolicyAc.Policy[i];
                //Use: processorPolicyInfoAc.DemotePercent;
                //Use: processorPolicyInfoAc.PromotePercent;
                
                //And don't forget to do the same for Dc (Dc is battery)
            }
        }
