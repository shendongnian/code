		public partial class TestClass {
			public static void TestExplicitOperator() {
				double d=2.5;
				Num<byte> b=(Num<byte>)d;
			}
		}
	and you've already seen the IL before: 
		IL_0000: nop
		IL_0001: ldc.r8 2.5
		IL_000a: stloc.0
		IL_000b: ldloc.0
		IL_000c: conv.u1
		IL_000d: call valuetype Num`1<!0> valuetype Num`1<uint8>::op_Explicit(!0)
		IL_0012: stloc.1
		IL_0013: ret
