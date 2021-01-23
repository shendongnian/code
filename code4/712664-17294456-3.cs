    IL_0001:  newobj      System.Collections.Generic.List<System.Int32>..ctor
    IL_0006:  stloc.2     // <>g__initLocal0
    IL_0007:  ldloc.2     // <>g__initLocal0
    IL_0008:  ldc.i4.1    
    ...
    ...
    ...
    IL_0058:  nop         
    IL_0059:  ldloc.2     // <>g__initLocal0
    IL_005A:  stloc.0     // numbers
    IL_005B:  ldloc.0     // numbers
    IL_005C:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate3
    IL_0061:  brtrue.s    IL_0076
    IL_0063:  ldnull      
    IL_0064:  ldftn       b__1
    IL_006A:  newobj      System.Func<System.Int32,System.Boolean>..ctor
    IL_006F:  stsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate3
    IL_0074:  br.s        IL_0076
    IL_0076:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate3
    IL_007B:  call        System.Linq.Enumerable.Where  <--------first where call
    IL_0080:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate4
    IL_0085:  brtrue.s    IL_009A
    IL_0087:  ldnull      
    IL_0088:  ldftn       b__2
    IL_008E:  newobj      System.Func<System.Int32,System.Boolean>..ctor
    IL_0093:  stsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate4
    IL_0098:  br.s        IL_009A
    IL_009A:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate4
    IL_009F:  call        System.Linq.Enumerable.Where  <--------second where call
    IL_00A4:  stloc.1     // query
    IL_00A5:  ldloc.1     // query
    
    b__1:
    IL_0000:  ldarg.0     
    IL_0001:  ldc.i4.2    
    IL_0002:  cgt         
    IL_0004:  stloc.0     // CS$1$0000
    IL_0005:  br.s        IL_0007
    IL_0007:  ldloc.0     // CS$1$0000
    IL_0008:  ret         
    
    b__2:
    IL_0000:  ldarg.0     
    IL_0001:  ldc.i4.5    
    IL_0002:  clt         
    IL_0004:  stloc.0     // CS$1$0000
    IL_0005:  br.s        IL_0007
    IL_0007:  ldloc.0     // CS$1$0000
    IL_0008:  ret
