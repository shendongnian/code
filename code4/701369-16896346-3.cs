    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading;
    using System.Diagnostics;
    //using winform = System.Windows.Forms;
     using WindowsInput;
    /*
     * author:qwr
     *
     * */
    namespace Utils
    {
        /// <summary>
        /// Utility methods for using through the program
        /// </summary>
        class Util
        {
             
            /// <summary>
            /// Starting external program
            /// </summary>
            /// <param name="file_name">path of the executable file</param>
            /// <param name="arguments">arguments to be passed </param>
            /// <param name="hidden">options for showing windows</param>
            /// <returns>return Process if the function succeeds otherwise null</returns>
            public static Process StartProc(string file_name, string arguments,string workdir, bool hidden)
            {
                Process proc = null;
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    if (workdir!=null && workdir.Length>0) 
                        startInfo.WorkingDirectory = workdir;
                    if (arguments != null && arguments.Length > 0) 
                        startInfo.Arguments = arguments;
                    startInfo.FileName = file_name;  
                   
                    if (hidden == true)
                    {
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }//hidden
                    proc = new Process();
                    proc.StartInfo = startInfo;
                    proc.Start(); 
                    Debuglog("startProc started " + file_name);
                    
                }//try
                catch(Exception ex)
                {
                    Debuglog("startProc  " + file_name);
                    Debuglog("startProc error :"+ ex.Message);
                    proc = null;
                }//try-catch
    
                return proc;
            }//startproc
    
            /// <summary>
            /// Kill all instances of process by name
            /// </summary>
            /// <param name="name">name of process</param>
            public static void KillProc(string name)
            {
                Process[] Proclist = Process.GetProcessesByName(name);
                foreach (Process proc in Proclist)
                {
                    proc.Kill();
                }//for
                return;
    
            }//killproc
    
            /// <summary>
            /// Kill Process
            /// </summary>
            /// <param name="process"></param>
            public static void KillProc( Process process)
            {
                try
                {
                    if (process != null && process.HasExited == false)
                    {
                         process.Kill();
                         Util.Debuglog("trying to kill process..."+process.Id);
                    }//if null
                }//try
                catch (Exception ex)
                {  
                    Util.Debuglog("fail to kill");
                    ex.Message.toLog();
                    ex.StackTrace.toLog();
                }//try-catch
                 
            }
    
            /// <summary>
            /// Finds first occurence of the process instance by its name
            /// </summary>
            /// <param name="name">name of processed that will be searched</param>
            /// <returns>return Process on succed otherwise null</returns>
            public static Process FindByName(string name)
            {
                Process found = null;
                //need to find through name
                Process[] myProcess = Process.GetProcesses();
                foreach (Process p in myProcess)
                    if (p.ProcessName == name) { found = p; break; }
                return found;
            }
    
            /// <summary>
            /// Convert unix time to C# date
            /// </summary>
            /// <param name="unixTime"></param>
            /// <returns></returns>
            public static DateTime  CSharpTime(double unixTime)
            {
              DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0,DateTimeKind.Utc);
              return unixStartTime.AddSeconds(unixTime).ToLocalTime();
            }//ToCSharpTime
    
            /// <summary>
            /// Makes windows appear on the top
            /// </summary>
            /// <param name="handle">hadnle of window</param>
            public static void BringToFront(IntPtr handle)
            {
                native.WINDOWPLACEMENT wndP;
                native.GetWindowPlacement(handle, out wndP);
                if (wndP.ShowCmd == native.WindowShowStyle.ShowMinimized || wndP.ShowCmd == native.WindowShowStyle.Minimize)
                    native.ShowWindow(handle, native.WindowShowStyle.ShowDefault);
                native.SetForegroundWindow(handle);
            }
    
            /// <summary>
            /// simulating keyboard .
            /// </summary>
            /// <param name="message">message that will be typed</param>
            /// <param name="enterKey">indicates if enter key will be send after message</param>
            /// <remarks>this function uses windows.forms.sendkeys.sendwait
            /// for better performance you can use other simulators
            /// or direct text manipulation methods
            /// </remarks>
            public static void SimulateMessage(string message, bool enterKey)
            {
               // winform.SendKeys.SendWait(message); //calls application doevents inside
              //  if (enterKey) winform.SendKeys.SendWait("{ENTER}");
                InputSimulator.SimulateTextEntry(message);
                if (enterKey) InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
            }
    
            private static readonly object locker = new object(); 
            
            /// <summary>
            /// small log . debug only
            /// </summary>
            /// <param name="s"></param>
         // [ConditionalAttribute("DEBUG")] 
            public static void Debuglog(string s)
            {
                lock  (locker)
                 using (StreamWriter nm = new StreamWriter("log", true, Encoding.UTF8))
                 {
                    nm.Write(DateTime.Now.ToLongTimeString());
                    nm.Write("--- >  ");
                    nm.WriteLine(s);
                 }//using
            }
          
        }//end class
    }//end namespace
