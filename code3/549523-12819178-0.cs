    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using EnvDTE;
    using EnvDTE80;
    using System.IO;
    namespace InstallToolboxControls
    {
        // Definition of the IMessageFilter interface which we need to implement and 
        // register with the CoRegisterMessageFilter API.
        [ComImport(), Guid("00000016-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        interface IOleMessageFilter // Renamed to avoid confusion w/ System.Windows.Forms.IMessageFilter
        {
            [PreserveSig]
            int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);
            [PreserveSig]
            int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);
            [PreserveSig]
            int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
        }
        class Program : IOleMessageFilter
        {
            [DllImport("ole32.dll")]
            private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
            static string ctrlPath = "WindowsFormsControlLibrary2.FloorsGrouping, WindowsFormsControlLibrary2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=197889249da45bfc";//@"C:\Windows\Microsoft.NET\assembly\GAC_MSIL\WindowsFormsControlLibrary2\v4.0_1.0.0.0__197889249da45bfc\WindowsFormsControlLibrary2.dll";//@"E:\Rostami\Saino\Program\Tests\WindowsFormsControlLibrary2\WindowsFormsControlLibrary2\bin\Debug\WindowsFormsControlLibrary2.dll";
            [STAThread]
            public static void Toolbox(string arg)
            {
                Program program = new Program();
                program.Register();
                if (arg.Equals("Install", StringComparison.CurrentCultureIgnoreCase))
                {
                    program.InstallControl();
                }
                else if (arg.Equals("UnInstall", StringComparison.CurrentCultureIgnoreCase))
                {
                    program.UninstallControl();
                }
                program.Revoke();
                // to ensure the dte object is actually released, and the devenv.exe process terminates.
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            void InstallControl()
            {
                // Create an instance of the VS IDE,
                Type type = System.Type.GetTypeFromProgID("VisualStudio.DTE.10.0");
                DTE dte = (DTE)System.Activator.CreateInstance(type, true);
                // create a temporary winform project;
                string tmpFile = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
                string tmpDir = string.Format("{0}{1}", Path.GetTempPath(), tmpFile);
                Solution2 solution = dte.Solution as Solution2;
                string templatePath = solution.GetProjectTemplate("WindowsApplication.zip", "CSharp");
                Project proj = solution.AddFromTemplate(templatePath, tmpDir, "dummyproj", false);
                // add the control to the toolbox.
                EnvDTE.Window window = dte.Windows.Item(EnvDTE.Constants.vsWindowKindToolbox);
                EnvDTE.ToolBox toolbox = (EnvDTE.ToolBox)window.Object;
                EnvDTE.ToolBoxTab myTab = toolbox.ToolBoxTabs.Add("Saino");
                myTab.Activate();
                myTab.ToolBoxItems.Add("MyUserControl", ctrlPath, vsToolBoxItemFormat.vsToolBoxItemFormatDotNETComponent);
                dte.Solution.Close(false);
                Marshal.ReleaseComObject(dte);
                //Console.WriteLine("Control Installed!!!");
            }
            void UninstallControl()
            {
                Type type = System.Type.GetTypeFromProgID("VisualStudio.DTE.10.0");
                DTE dte = (DTE)System.Activator.CreateInstance(type, true);
                EnvDTE.Window window = dte.Windows.Item(EnvDTE.Constants.vsWindowKindToolbox);
                EnvDTE.ToolBox toolbox = (EnvDTE.ToolBox)window.Object;
                EnvDTE.ToolBoxTab myTab = toolbox.ToolBoxTabs.Item("Saino");
                myTab.Activate();
                myTab.Delete();
                Marshal.ReleaseComObject(dte);
                //Console.WriteLine("Control Uninstalled!!!");
            }
            void Register()
            {
                IOleMessageFilter oldFilter;
                CoRegisterMessageFilter(this, out oldFilter);
            }
            void Revoke()
            {
                IOleMessageFilter oldFilter;
                CoRegisterMessageFilter(null, out oldFilter);
            }
            #region IOleMessageFilter Members
            public int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
            {
                return 0; //SERVERCALL_ISHANDLED
            }
            public int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
            {
                if (dwRejectType == 2) // SERVERCALL_RETRYLATER
                {
                    return 200; // wait 2 seconds and try again
                }
                return -1; // cancel call
            }
            public int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
            {
                return 2; //PENDINGMSG_WAITDEFPROCESS
            }
            #endregion
        }
    }
