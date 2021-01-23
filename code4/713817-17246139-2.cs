    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                       
        private void But_StartPinvoke_Click(object sender, EventArgs e)
        {
            var userInputOK = TBX_SelectedProcessName.userInput();
            if(!userInputOK)
                MessageBox.Show(RApss.mesgs.EmptyTbx);
            RApss.Strings.UserInput = TBX_SelectedProcessName.Text;
            RApss.Globs.TbxPname = TBX_SelectedProcessName.Text.AddSufixEXE();
            doWarmUp();
            Stopwatch SwGpbn = Stopwatch.StartNew();
            SwGpbn.Start();
            //string _netProcName = Process.GetProcessesByName(RApss.Strings.UserInput)[0].ProcessName;
            Process p = Process.GetProcessesByName(RApss.Strings.UserInput)[0];
            if (p.ProcessName.ResultFetched())
            SwGpbn.Stop();
            var msElps_Net4 = SwGpbn.ElapsedMilliseconds;
            SwGpbn.Reset();
            SwGpbn.Start();
            EnumProcessesV3.GetProcessByName();
            SwGpbn.Stop();
            var msElpsNat = SwGpbn.ElapsedMilliseconds;
            SwGpbn.Reset();
            SwGpbn.Reset();
            if (RApss.Globs.Result.ResultFetched()) MessageBox.Show(string.Concat(RApss.Globs.Result, "\r\nWas Fetched In: ", msElpsNat, " Via PinVoke\r\n Was Fetched In: ", msElps_Net4," Via C#.NET !" ));
        }
        private void doWarmUp()
        {
            List<string> swarm = new List<string>();
            for (int i = 0; i < 50000; i++)
            {
               swarm.Add((i + 1 *500).ToString());
            }
        }
    }
    public class RApss
    {
        public class Globs
        {
            public static string TbxPname;
            public static string Result = string.Empty;
        }
        public class Strings
        {
            public static string intputForProcessName = "Requiered Process Name";
            public static string UserInput = string.Empty;
        }
        public class mesgs
        {
            public static string EmptyTbx = string.Concat("please fill ", Strings.intputForProcessName, " field");
        }
    } 
       public class EnumProcessesV3
       {
      
        #region APIS
        [DllImport("psapi")]
        private static extern bool EnumProcesses(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)] [In][Out] IntPtr[] processIds,
            UInt32 arraySizeBytes, 
            [MarshalAs(UnmanagedType.U4)] out UInt32 bytesCopied);
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, IntPtr dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] int nSize);
        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool EnumProcessModules(IntPtr hProcess,
        [Out] IntPtr lphModule,
        uint cb,
        [MarshalAs(UnmanagedType.U4)] out uint lpcbNeeded);
        [DllImport("psapi.dll")]
        static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In] [MarshalAs(UnmanagedType.U4)] int nSize);
        #endregion
        #region ENUMS
        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
        #endregion
        public static void GetProcessByName()
        {
            UInt32 arraySize = 120;
            UInt32 arrayBytesSize = arraySize * sizeof(UInt32);
            IntPtr[] processIds = new IntPtr[arraySize];
            UInt32 bytesCopied;
            bool success = EnumProcesses(processIds, arrayBytesSize, out bytesCopied);
            #region <<=========== some cleanUps  ============>>
            // trying to check what could have been taking extra mssssnds
            //Console.WriteLine("success={0}", success);
            //Console.WriteLine("bytesCopied={0}", bytesCopied);
            //if (!success)
            //{
            //    MessageBox.Show("Boo!");
            //    return;
            //}
            //if (0 == bytesCopied)
            //{
            //    MessageBox.Show("Nobody home!");
            //    return;
            //}
            #endregion
            UInt32 numIdsCopied = bytesCopied >> 2;
            #region <<===========same here commenting anything that might cost nerowing the options   ============>>
            //if (0 != (bytesCopied & 3))
            //{
            //    UInt32 partialDwordBytes = bytesCopied & 3;
            //    MessageBox.Show(String.Format("EnumProcesses copied {0} and {1}/4th DWORDS...  Please ask it for the other {2}/4th DWORD",
            //        numIdsCopied, partialDwordBytes, 4 - partialDwordBytes));
            //    return;
            //}
            //taking initialisation of SB out of loop was a winning thought but nada no change maybe in nanos
            #endregion
            for (UInt32 index = numIdsCopied; index> 1 ; index--) // reversing from last process id(chitting) to erlier process id did not help to win the contest
            {
                StringBuilder szProcessName = new StringBuilder(1000);
                int x = szProcessName.Capacity;
                string sName = PrintProcessName(processIds[index-1],szProcessName,x);
                if (sName.Equals(RApss.Globs.TbxPname)) // tryng hardcoded value instead of reading from a variable.(GlobalsClass)
                {
                    RApss.Globs.Result = sName; 
                    break;
                }
                ////////IntPtr PID = processIds[index];
                ////////Console.WriteLine("Name '" + sName + "' PID '" + PID + "'");
            }
        }
        static string PrintProcessName(IntPtr processID, StringBuilder sb, int Cpcty)
        {
            string sName = "";
            //bool bFound = false;
            IntPtr hProcess = OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VMRead, false, processID);
            if (hProcess != IntPtr.Zero)
            {
                IntPtr hMod = IntPtr.Zero;
                uint cbNeeded = 0;
                EnumProcessModules(hProcess, hMod, (uint)Marshal.SizeOf(typeof(IntPtr)), out cbNeeded);
                if (GetModuleBaseName(hProcess, hMod, sb, Cpcty) > 0)
                {
                    sName = sb.ToString();
                    
                    //bFound = true;
                }
                // Close the process handle
                CloseHandle(hProcess);
            }
            //if (!bFound)
            //{
            //    sName = "<unknown>";
            //}
            return sName;
        }
      }
    }
    namespace RExt
    {
        public static class UserInputs
        {
            public static bool userInput(this TextBox tbxId)
            {
                return tbxId.Text.Length > 1;
            }
        }
        public static class strExt
        {
            public static bool ResultFetched(this string StrToCheck)
            {
                return !string.IsNullOrWhiteSpace(StrToCheck);
            }
            public static string AddSufixEXE(this string StrToAppendEXE)
            {
                return string.Concat(StrToAppendEXE, ".exe");
            }
        }
    }
