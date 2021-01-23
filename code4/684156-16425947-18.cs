		public partial class TestClass {
			public static void TestGenericMethodBySpecifyingTypeParameter() {
				double d=2.5;
				Num<byte> b=NumHelper.From<byte>(d);
			}
		}
