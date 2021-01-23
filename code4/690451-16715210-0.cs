    .method public hidebysig specialname virtual 
        instance string  get_Location() cil managed
    {
      .custom instance void System.Security.SecuritySafeCriticalAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       37 (0x25)
      .maxstack  3
      .locals init (string V_0)
      IL_0000:  ldnull
      IL_0001:  stloc.0
      IL_0002:  ldarg.0
      IL_0003:  call       instance class System.Reflection.RuntimeAssembly System.Reflection.RuntimeAssembly::GetNativeHandle()
      IL_0008:  ldloca.s   V_0
      IL_000a:  call       valuetype System.Runtime.CompilerServices.StringHandleOnStack System.Runtime.CompilerServices.JitHelpers::GetStringHandleOnStack(string&)
      IL_000f:  call       void System.Reflection.RuntimeAssembly::GetLocation(class System.Reflection.RuntimeAssembly,
                                                                           valuetype System.Runtime.CompilerServices.StringHandleOnStack)
      IL_0014:  ldloc.0
      IL_0015:  brfalse.s  IL_0023
      IL_0017:  ldc.i4.8
      IL_0018:  ldloc.0
      IL_0019:  newobj     instance void System.Security.Permissions.FileIOPermission::.ctor(valuetype System.Security.Permissions.FileIOPermissionAccess,
                                                                                         string)
      IL_001e:  call       instance void System.Security.CodeAccessPermission::Demand()
      IL_0023:  ldloc.0
      IL_0024:  ret
    } // end of method RuntimeAssembly::get_Location
