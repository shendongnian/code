        .method private hidebysig static void  foo() cil managed
    {
      // Code size       37 (0x25)
      .maxstack  4
      .locals init ([0] class [System.Data]System.Data.SqlClient.SqlCommand command)
      IL_0000:  newobj     instance void [System.Data]System.Data.SqlClient.SqlCommand::.ctor()
      IL_0005:  stloc.0
      IL_0006:  ldloc.0
      IL_0007:  callvirt   instance class [System.Data]System.Data.SqlClient.SqlParameterCollection [System.Data]System.Data.SqlClient.SqlCommand::get_Parameters()
      IL_000c:  ldstr      "@Name"
      IL_0011:  ldc.i4.s   12
      IL_0013:  ldc.i4.s   50
      IL_0015:  callvirt   instance class [System.Data]System.Data.SqlClient.SqlParameter [System.Data]System.Data.SqlClient.SqlParameterCollection::Add(string,
                                                                                                                                                         valuetype [System.Data]System.Data.SqlDbType,
                                                                                                                                                         int32)
      IL_001a:  ldstr      ""
      IL_001f:  callvirt   instance void [System.Data]System.Data.Common.DbParameter::set_Value(object)
      IL_0024:  ret
    } // end of method Program::foo
