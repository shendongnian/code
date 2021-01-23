    // enable logging all queries executed by EF
    var cx = ((IObjectContextAdapter)this).ObjectContext; // change to var cx = this; if using ObjectContext.
    cx.EnableTracing();
    cx.Connection.GetTracingConnections().ToList().ForEach(
        c =>
        {
            c.CommandExecuting += (s, e) => Log(e);
            c.CommandFailed += (s, e) => Log(e);
            c.CommandFinished += (s, e) => Log(e);
        });
