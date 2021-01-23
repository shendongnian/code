    IL_0067:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_006C:  brtrue.s    IL_007F
    IL_006E:  ldnull      
    IL_006F:  ldftn       b__0
    IL_0075:  newobj      System.Func<<>f__AnonymousType0<System.Int32,System.String>,System.Boolean>..ctor
    IL_007A:  stsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_007F:  ldsfld      UserQuery.CS$<>9__CachedAnonymousMethodDelegate1
    IL_0084:  call        System.Linq.Enumerable.Where   <-----
    IL_0089:  stloc.2     // myVar
    IL_008A:  ldloc.2     // myVar
    IL_008B:  call        System.Linq.Enumerable.Any     <-----
    IL_0090:  brfalse.s   IL_009E
    IL_0092:  ldloc.2     // myVar
    IL_0093:  call        System.Linq.Enumerable.First   <-----
    IL_0098:  callvirt    <>f__AnonymousType0<System.Int32,System.String>.get_MyName
    IL_009D:  stloc.1     // anotherVar
    IL_009E:  ldloc.1     // anotherVar
