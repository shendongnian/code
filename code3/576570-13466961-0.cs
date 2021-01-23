        static System.Windows.Forms.Timer tTimer;
        const Int32 iInterval = 30;
        static Boolean IsProcessRunning = false;
        static Int32 iProcessID = 0;
        static Int32 SetTimerInterval(Int32 minute)
        {
            if (minute <= 0)
                minute = 60;
            DateTime now = DateTime.Now;
            DateTime next = now.AddMinutes((minute - (now.Minute % minute))).AddSeconds(now.Second * -1).AddMilliseconds(now.Millisecond * -1);
            TimeSpan interval = next - now;
            return (Int32)interval.TotalMilliseconds;
        }
        static void timer_Tick(object sender, EventArgs e)
        {   
            if (!IsProcessRunning)
            {   
                ProcessStartInfo objStartInfo = new ProcessStartInfo();
                objStartInfo.FileName = "C:\\Windows\\notepad.exe";
                Process objProcess = new Process();
                objProcess.StartInfo = objStartInfo;
                objProcess.Start();
                iProcessID = objProcess.Id;
                IsProcessRunning = true;
            }
            else
            {
                Process objProcess = Process.GetProcessById(iProcessID);
                objProcess.Kill();
                IsProcessRunning = false;
            }
            tTimer.Interval = SetTimerInterval(iInterval);
        }
