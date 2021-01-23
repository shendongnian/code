    int id = ...
    try
    {
        var proc = Process.GetProcessById(id);
    }
    catch
    {
        // no process running with that id
    }
