    warnif count > 0 from m in Methods where
     m.IsUsing ("YourNamespace.YourClass.foo") && ( 
       ! m.IsUsing ("YourNamespace.YourClass.bar") ||
       ! m.IsUsing ("System.Threading.Monitor.Enter(Object)".AllowNoMatch()) ||
       ! m.IsUsing ("System.Threading.Monitor.Exit(Object)".AllowNoMatch()) )
    select new { m, m.NbLinesOfCode }
