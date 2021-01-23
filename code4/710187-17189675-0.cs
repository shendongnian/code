    public class MyPerfoamnceCounter
    {
        public string pc()
        {
            Dictionary<string, List<PerformanceCounter>> counters =
        new Dictionary<string, List<PerformanceCounter>>();
            List<PerformanceCounter> cpuList = new List<PerformanceCounter>();
            List<PerformanceCounter> procList = new List<PerformanceCounter>();
            List<PerformanceCounter> memList = new List<PerformanceCounter>();
            PerformanceCounterCategory perfCat = new PerformanceCounterCategory();
    foreach (Process process in Process.GetProcesses()) {
        
        PerformanceCounter procProcesTimeCounter  = new PerformanceCounter(
             "Process", 
            "% Processor Time", 
            process.ProcessName);
        var proc = procProcesTimeCounter; procList.Add(proc);
        procProcesTimeCounter.NextValue(); 
        
        PerformanceCounter procCPUTimeCounter = new PerformanceCounter(
             "Processor",
            "% Processor Time",
            process.ProcessName);
         //procCPUTimeCounter.CategoryName= "Processor";
         perfCat.CategoryName = procCPUTimeCounter.CategoryName;
         var ex = PerformanceCounterCategory.Exists("Processor");
         if (ex)
         {
             cpuList.Add(procCPUTimeCounter);
             //if(procCPUTimeCounter.InstanceName
             //if(procCPUTimeCounter.InstanceName == process.ProcessName)
             procCPUTimeCounter.NextValue();
         }
        
        PerformanceCounter procMemTimeCounter = new PerformanceCounter(
             "Memory", "Available MBytes",
            process.ProcessName);
        ex = perfCat.InstanceExists(process.ProcessName);
        if (ex)
        {
            var mem = procMemTimeCounter; memList.Add(mem);
            procMemTimeCounter.NextValue();
        }
        /*
        var oktoplot = Convert.ToUInt32(v) != 0;
        if (oktoplot)
        counters.Add(procProcesTimeCounter);
        */
    }
    counters.Add("CPUs", cpuList);
    counters.Add("PROCs", procList);
    counters.Add("MEMs", memList);
            
    System.Threading.Thread.Sleep(2250); // 1 second wait  ("Memory", "Available MBytes")
    StringBuilder SbRw = new StringBuilder();
    SbRw.Append("<table id = 'tblMainCounters'>");
    List<string> couterNames = new List<string>();
    foreach (string cName in counters.Keys)
    {
        couterNames.Add(cName);
    }
    foreach (string cNameStr in couterNames)
    {
        
        SbRw.Append("\r\n\t<tr>\r\n\t\t<td>\r\n\t\t\t<table id='tbl" + cNameStr + "'>\r\n\t\t\t\t");
        for (int i = 0; i < counters[cNameStr].Count; i++)
        {
            //string ToPRint = counters[cNameStr].ElementAt(i).NextValue().ToString();
            //bool OkToprint = string.IsNullOrEmpty(ToPRint) == false && ToPRint != (0.0).ToString() && ToPRint != (0).ToString();
            //if (OkToprint)
            SbRw.Append(string.Format("\r\n\t\t\t\t\t<tr id='{0}List{1}'>\r\n\t\t\t\t\t\t<td>Category : </td><td>{2}</td><td> Process : </td><td>{3}</td><td> CounterName : </td><td>{4}</td><td> CPU Usage : </td><td><b> {5}%</b></td>\r\n\t\t\t\t\t</tr>",
                cNameStr,
                i.ToString(),
                counters[cNameStr].ElementAt(i).CategoryName,
                counters[cNameStr].ElementAt(i).InstanceName,
                counters[cNameStr].ElementAt(i).CounterName,
                counters[cNameStr].ElementAt(i).NextValue()));
        }
        SbRw.Append("</table><!-- Closing table_" + cNameStr + " -->\r\n\t\t\t</td>\r\n\t\t</tr>");
    }
    SbRw.Append("</table><!-- Closing tableMainCounters --><br /><br />");
  
    return(SbRw.ToString()); 
        
        
        
        
        
        
