    Process.GetProcesses().Count(m => m.ProcessName.StartsWith("S"));
    IL_0001:  call        System.Diagnostics.Process.GetProcesses
    IL_0006:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_000B:  brtrue.s    IL_0020
    IL_000D:  ldnull      
    IL_000E:  ldftn       b__0
    IL_0014:  newobj      System.Func<System.Diagnostics.Process,System.Boolean>..ctor
    IL_0019:  stsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_001E:  br.s        IL_0020
    IL_0020:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_0025:  call        System.Linq.Enumerable.Count
    Process.GetProcesses().Where(m => m.ProcessName.StartsWith("S")).Count();
    IL_0001:  call        System.Diagnostics.Process.GetProcesses
    IL_0006:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_000B:  brtrue.s    IL_0020
    IL_000D:  ldnull      
    IL_000E:  ldftn       b__0
    IL_0014:  newobj      System.Func<System.Diagnostics.Process,System.Boolean>..ctor
    IL_0019:  stsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_001E:  br.s        IL_0020
    IL_0020:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_0025:  call        System.Linq.Enumerable.Where
    IL_002A:  call        System.Linq.Enumerable.Count
    b__0:
    IL_0000:  ldarg.0     
    IL_0001:  callvirt    System.Diagnostics.Process.get_ProcessName
    IL_0006:  ldstr       "S"
    IL_000B:  callvirt    System.String.StartsWith
    IL_0010:  stloc.0     // CS$1$0000
    IL_0011:  br.s        IL_0013
    IL_0013:  ldloc.0     // CS$1$0000
    IL_0014:  ret 
