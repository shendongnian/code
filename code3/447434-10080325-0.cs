    IOrderedEnumerable<Process> query = Process.GetProcesses()
                                        .OrderBy(p => p.WorkingSet64)
                                        .ThenByDescending(p => p.Threads.Count);
    
    // Won't work because Where doesn't return an IOrderedEnumerable.
    query = query.Where(p => p.ProcessName.Length < 9);
