		public static class NumHelper {
			public static Num<T> From<T>(T value) {
				return new Num<T>(value);
			}
		}
		public partial class TestClass {
			public static void TestGenericMethodWithExplicitConversion() {
				double d=2.5;
				Num<byte> b=NumHelper.From((byte)d);
			}
		}
	and the generated IL of the test method is: 
		IL_0000: nop
		IL_0001: ldc.r8 2.5
		IL_000a: stloc.0
		IL_000b: ldloc.0
		IL_000c: conv.u1
		IL_000d: call valuetype Num`1<!!0> NumHelper::From<uint8>(!!0)
		IL_0012: stloc.1
		IL_0013: ret
