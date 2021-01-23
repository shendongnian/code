  // public Test(string s)
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    // int tempValue = int.Parse(s);
    IL_0002:  call       int32 [mscorlib]System.Int32::Parse(string)
    // : this(tempValue)
    IL_0007:  call       instance void ContractConstructorTest.Test::.ctor(int32)
    IL_000e:  ldarg.1
    IL_000f:  ldnull
    // bool isNull = s == null;
    IL_0010:  ceq
    IL_0012:  ldc.i4.0
    // bool isNotNull = isNull == false;
    IL_0013:  ceq
    // Contract.Requires(isNotNull);
    IL_0015:  call       void [mscorlib]System.Diagnostics.Contracts.Contract::Requires(bool)
    IL_001c:  ret
  } // end of method Test::.ctor
