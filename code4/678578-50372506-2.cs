    g__Print10_0://Print1
    IL_0000:  ldarg.0     
    IL_0001:  stloc.0     
    IL_0002:  ldc.i4.0    
    IL_0003:  stloc.1     
    IL_0004:  br.s        IL_0012
    IL_0006:  ldloc.0     
    IL_0007:  ldloc.1     
    IL_0008:  ldelem.ref  
    IL_0009:  call        System.Console.Write
    IL_000E:  ldloc.1     
    IL_000F:  ldc.i4.1    
    IL_0010:  add         
    IL_0011:  stloc.1     
    IL_0012:  ldloc.1     
    IL_0013:  ldloc.0     
    IL_0014:  ldlen       
    IL_0015:  conv.i4     
    IL_0016:  blt.s       IL_0006
    IL_0018:  ret         
    g__Print20_1://Print2
    IL_0000:  ldarg.0     
    IL_0001:  call        System.Linq.Enumerable.ToList<String>
    IL_0006:  ldnull      
    IL_0007:  ldftn       System.Console.Write
    IL_000D:  newobj      System.Action<System.String>..ctor
    IL_0012:  callvirt    System.Collections.Generic.List<System.String>.ForEach
    IL_0017:  ret         
    g__Print30_2://Print3
    IL_0000:  ldstr       ""
    IL_0005:  ldarg.0     
    IL_0006:  call        System.String.Join
    IL_000B:  call        System.Console.WriteLine
    IL_0010:  ret         
    g__Print40_3://Print4
    IL_0000:  ldarg.0     
    IL_0001:  ldnull      
    IL_0002:  ldftn       System.Console.Write
    IL_0008:  newobj      System.Action<System.String>..ctor
    IL_000D:  call        System.Array.ForEach<String>
    IL_0012:  ret   
