    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace Diagnostic_Tool_Blue_Screen
    {
        public class GetSystemInfo
        {
            [DllImport("user32.dll")]
            private static extern int FindWindow(string className, string windowText);
    
            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);
    
            public void GetInfo(string path)
            {
                using (Process exeObj = new Process())
                {
                    exeObj.StartInfo.FileName = "msinfo32.exe";
                    exeObj.StartInfo.Arguments = string.Format("{0}{1}{2}", "/nfo ", path, @"\mysysinfo.nfo");
    
                    exeObj.StartInfo.UseShellExecute = false;
                    exeObj.StartInfo.RedirectStandardInput = true;
                    exeObj.StartInfo.RedirectStandardOutput = true;
                    exeObj.EnableRaisingEvents = true;
                    exeObj.Start();
                    exeObj.BeginOutputReadLine();
                    exeObj.Close();
                }
    
                Thread.Sleep(1000);
                const int SW_HIDE = 0;
    
                int hwnd = FindWindow(null, "System Information");
    
                if (hwnd != 0)
                {
                    var num = ShowWindow(hwnd, SW_HIDE);
                }
            }
        }
    }
