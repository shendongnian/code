    internal class clsNetworkStats
    {
        // Fields
        private const long ERROR_SUCCESS = 0L;
        private ArrayList m_Adapters;
        private const long MAX_INTERFACE_NAME_LEN = 0x100L;
        private const long MAXLEN_IFDESCR = 0x100L;
        private const long MAXLEN_PHYSADDR = 8L;
        // Methods
        public clsNetworkStats()
            : this(true)
        {
        }
        public clsNetworkStats(bool IgnoreLoopBack)
        {
            int lRetSize = 0;
            MIB_IFROW ifrow = new MIB_IFROW();
            byte[] buff = new byte[1];
            byte val = 0;
            long ret = GetIfTable(ref val, ref lRetSize, 0);
            buff = new byte[lRetSize];
            ret = GetIfTable(ref buff[0], ref lRetSize, 0);
            int lRows = buff[0];
            this.m_Adapters = new ArrayList(lRows);
            byte len = (byte)lRows;
            for (byte i = 1; i <= len; i++)
            {
                ifrow = new MIB_IFROW();
                ifrow.dwIndex = Convert.ToUInt32(i);
                ret = GetIfEntry(ref ifrow);
                IFROW_HELPER ifhelp = this.PrivToPub(ifrow);
                if (IgnoreLoopBack)
                {
                    if (ifhelp.Description.IndexOf("Loopback") < 0)
                    {
                        this.m_Adapters.Add(ifhelp);
                    }
                }
                else
                {
                    this.m_Adapters.Add(ifhelp);
                }
            }
        }
        public IFROW_HELPER GetAdapter(int index)
        {
            return (IFROW_HELPER)this.m_Adapters[index];
        }
        public int Count
        {
            get
            {
                return this.m_Adapters.Count;
            }
        }
        [DllImport("iphlpapi")]
        private static extern int GetIfEntry(ref MIB_IFROW pIfRow);
        [DllImport("iphlpapi")]
        private static extern int GetIfTable(ref byte pIfRowTable, ref int pdwSize, int bOrder);
        //[DebuggerStepThrough]
        private IFROW_HELPER PrivToPub(MIB_IFROW pri)
        {
            IFROW_HELPER ifhelp = new IFROW_HELPER();
            ifhelp.Name = pri.wszName.Trim();
            ifhelp.Index = Convert.ToInt32(pri.dwIndex);
            ifhelp.Type = Convert.ToInt32(pri.dwType);
            ifhelp.Mtu = Convert.ToInt32(pri.dwMtu);
            ifhelp.Speed = Convert.ToInt32(pri.dwSpeed);
            ifhelp.PhysAddrLen = Convert.ToInt32(pri.dwPhysAddrLen);
            ifhelp.PhysAddr = Encoding.ASCII.GetString(pri.bPhysAddr);
            ifhelp.AdminStatus = Convert.ToInt32(pri.dwAdminStatus);
            ifhelp.OperStatus = Convert.ToInt32(pri.dwOperStatus);
            ifhelp.LastChange = Convert.ToInt32(pri.dwLastChange);
            ifhelp.InOctets = pri.dwInOctets; //Convert.ToInt32(pri.dwInOctets);
            ifhelp.InUcastPkts = Convert.ToInt32(pri.dwInUcastPkts);
            ifhelp.InNUcastPkts = Convert.ToInt32(pri.dwInNUcastPkts);
            ifhelp.InDiscards = Convert.ToInt32(pri.dwInDiscards);
            ifhelp.InErrors = Convert.ToInt32(pri.dwInErrors);
            ifhelp.InUnknownProtos = Convert.ToInt32(pri.dwInUnknownProtos);
            ifhelp.OutOctets = pri.dwOutOctets;//Convert.ToInt32(pri.dwOutOctets);
            ifhelp.OutUcastPkts = Convert.ToInt32(pri.dwOutUcastPkts);
            ifhelp.OutNUcastPkts = Convert.ToInt32(pri.dwOutNUcastPkts);
            ifhelp.OutDiscards = Convert.ToInt32(pri.dwOutDiscards);
            ifhelp.OutErrors = Convert.ToInt32(pri.dwOutErrors);
            ifhelp.OutQLen = Convert.ToInt32(pri.dwOutQLen);
            ifhelp.Description = Encoding.ASCII.GetString(pri.bDescr, 0, Convert.ToInt32(pri.dwDescrLen));
            ifhelp.InMegs = this.ToMegs((long)ifhelp.InOctets);
            ifhelp.OutMegs = this.ToMegs((long)ifhelp.OutOctets);
            return ifhelp;
        }
        [DebuggerStepThrough]
        private string ToMegs(long lSize)
        {
            string sDenominator = " B";
            if (lSize > 0x3e8L)
            {
                sDenominator = " KB";
                lSize = (long)Math.Round((double)(((double)lSize) / 1000.0));
            }
            else if (lSize <= 0x3e8L)
            {
                sDenominator = " B";
                //            lSize = lSize;
            }
            return lSize.ToString("###,###") + sDenominator;
            //            (Strings.Format(lSize, "###,###0") + sDenominator);
        }
        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        public struct IFROW_HELPER
        {
            public string Name;
            public int Index;
            public int Type;
            public int Mtu;
            public int Speed;
            public int PhysAddrLen;
            public string PhysAddr;
            public int AdminStatus;
            public int OperStatus;
            public int LastChange;
            public uint InOctets;   //changed
            public int InUcastPkts;
            public int InNUcastPkts;
            public int InDiscards;
            public int InErrors;
            public int InUnknownProtos;
            public uint OutOctets;  //changed
            public int OutUcastPkts;
            public int OutNUcastPkts;
            public int OutDiscards;
            public int OutErrors;
            public int OutQLen;
            public string Description;
            public string InMegs;
            public string OutMegs;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct MIB_IFROW
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x100)]
            public string wszName;
            public uint dwIndex;
            public uint dwType;
            public uint dwMtu;
            public uint dwSpeed;
            public uint dwPhysAddrLen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] bPhysAddr;
            public uint dwAdminStatus;
            public uint dwOperStatus;
            public uint dwLastChange;
            public uint dwInOctets;
            public uint dwInUcastPkts;
            public uint dwInNUcastPkts;
            public uint dwInDiscards;
            public uint dwInErrors;
            public uint dwInUnknownProtos;
            public uint dwOutOctets;
            public uint dwOutUcastPkts;
            public uint dwOutNUcastPkts;
            public uint dwOutDiscards;
            public uint dwOutErrors;
            public uint dwOutQLen;
            public uint dwDescrLen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x100)]
            public byte[] bDescr;
        }
        public static int GetInterfaceIndex(string description)
        {
            int val = 0;
            clsNetworkStats stats = new clsNetworkStats();
            for (int index = 0; index < stats.Count; index++)
            {
                string desc = stats.GetAdapter(index).Description;
                if (desc == description + "\0")
                {
                    val = stats.GetAdapter(index).Index;
                    break;
                }
            }
            return val;
        }
    }
