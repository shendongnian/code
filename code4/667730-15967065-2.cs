    class CounterLocked
    {
     private static object o;
     private static int s_Number = 0;
     public static int GetNextNumber()
     {
      lock(o)
      {
        s_Number++;
        return s_Number;
      }
     }
    }
    
    
    CounterLocked.GetNextNumber:
    IL_0000:  ldc.i4.0    
    IL_0001:  stloc.0     // <>s__LockTaken0
    IL_0002:  ldsfld      UserQuery+CounterLocked.o
    IL_0007:  dup         
    IL_0008:  stloc.2     // CS$2$0001
    IL_0009:  ldloca.s    00 // <>s__LockTaken0
    IL_000B:  call        System.Threading.Monitor.Enter
    IL_0010:  ldsfld      UserQuery+CounterLocked.s_Number
    IL_0015:  ldc.i4.1    
    IL_0016:  add         
    IL_0017:  stsfld      UserQuery+CounterLocked.s_Number
    IL_001C:  ldsfld      UserQuery+CounterLocked.s_Number
    IL_0021:  stloc.1     // CS$1$0000
    IL_0022:  leave.s     IL_002E
    IL_0024:  ldloc.0     // <>s__LockTaken0
    IL_0025:  brfalse.s   IL_002D
    IL_0027:  ldloc.2     // CS$2$0001
    IL_0028:  call        System.Threading.Monitor.Exit
    IL_002D:  endfinally  
    IL_002E:  ldloc.1     // CS$1$0000
    IL_002F:  ret        
