    public static void TestOut(out int test)
    {
        test = 1;
    }
    .method public hidebysig static void  TestOut([out] int32& test) cil managed
    {
      // Code size       4 (0x4)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldc.i4.1
      IL_0002:  stind.i4
      IL_0003:  ret
    } // end of method Program::TestOut
