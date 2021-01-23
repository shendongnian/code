    .method private hidebysig static void  bar() cil managed
    {
      // Code size       39 (0x27)
      .maxstack  4
      .locals init ([0] class [System.Data]System.Data.SqlClient.SqlCommand command,
               [1] class [System.Data]System.Data.SqlClient.SqlParameterCollection cp)
      IL_0000:  newobj     instance void [System.Data]System.Data.SqlClient.SqlCommand::.ctor()
      IL_0005:  stloc.0
      IL_0006:  ldloc.0
      IL_0007:  callvirt   instance class [System.Data]System.Data.SqlClient.SqlParameterCollection [System.Data]System.Data.SqlClient.SqlCommand::get_Parameters()
      IL_000c:  stloc.1
      IL_000d:  ldloc.1
      IL_000e:  ldstr      "@Name"
      IL_0013:  ldc.i4.s   12
      IL_0015:  ldc.i4.s   50
      IL_0017:  callvirt   instance class [System.Data]System.Data.SqlClient.SqlParameter [System.Data]System.Data.SqlClient.SqlParameterCollection::Add(string,
                                                                                                                                                         valuetype [System.Data]System.Data.SqlDbType,
                                                                                                                                                         int32)
      IL_001c:  ldstr      ""
      IL_0021:  callvirt   instance void [System.Data]System.Data.Common.DbParameter::set_Value(object)
      IL_0026:  ret
    } // end of method Program::bar
