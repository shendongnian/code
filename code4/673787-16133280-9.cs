    HashSet<Process> anHashOfProcesses = new HashSet<Process>(Process.GetProcesses());
    foreach(string s in myProcesses)
    {
        var p = anHashOfProcesses.FirstOrDefault(z => z.ProcessName + ".exe" == s);
        if(p != null) listBox1.Items.Add(p.ProcessName + " - " + p.Id);
    }
