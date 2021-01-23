    foreach (var p in Process.GetProcesses())
    {
         sb.Append("\r\n");
         sb.Append("Process Name: " + p.ProcessName);
         sb.Append("\r\n");
    }
