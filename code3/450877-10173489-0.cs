    private ulong GetCPU(ThreadEntry[] thList) 
    { 
      ulong result = 0; 
      for (int i = 0; i < thList.Length; i++) 
      { 
        ulong NewThC = 0; 
        ulong NewThE = 0; 
        ulong NewThK = 0; 
        ulong NewThU = 0; 
        if(GetThreadTimes(thList[i].ThreadID, ref NewThC, ref NewThE, ref NewThK, ref NewThU)) 
          result = result + NewThK + NewThU; 
        int error = Marshal.GetLastWin32Error(); 
    //often ERROR == 6 or ERROR == 18
      } 
      return result; 
    } 
 
    //GET ALL PROCESS CPU USAGE 
    private void timer1_Tick(object sender, EventArgs e) 
    { 
    //reset results 
      this.textBox1.Text = string.Empty; 
    //turn of timer 
      this.Enabled = false; 
      uint perm = GetCurrentPermissions();
      //SET PERMISION SO I CAN RECEIVE INFO ABOUT THREADS
      SetProcPermissions(0xFFFFFFFF);
    //get all running process (OPENNETCF)       
      List<ProcessEntry> processList = new List<ProcessEntry>(ProcessEntry.GetProcesses()); 
 
    //OLD Variables stored in list 
      if (OldResList == null || (OldResList != null && OldResList.Length !=   processList.Count)) 
        OldResList = new ulong[processList.Count]; 
 
    //SORT by ID only for testing       
      processList.Sort(CompareProcessEntry); 
    //GET ALL CPU USAGE       
      for(int i=0;i<processList.Count;i++) 
      { 
      //new value 
        ulong newRes = GetCPU( processList[i].GetThreads() ); 
      //result 
        ulong result = (newRes - OldResList[i]); 
      //valid result 
        result = result / (ulong)this.timer1.Interval; 
      //set result to the thexbox 
        this.textBox1.Text += processList[i].ExeFile + " " +  result.ToString() + " ;"; 
      //change old to new 
        OldResList[i] = newRes; 
      } 
      //sleep 
      Thread.Sleep(1000); 
      SetProcPermissions(0xFFFFFFFF);
      //start again 
      timer1.Enabled = true; 
      } 
      public static int CompareProcessEntry(ProcessEntry p1, ProcessEntry p2) 
      { 
       return p1.ProcessID.CompareTo(p2.ProcessID); 
      } 
 
      [DllImport("coredll")] 
      private static extern bool GetThreadTimes(uint p, ref ulong NewThC, ref ulong NewThE, ref ulong NewThK, ref ulong NewThU); 
