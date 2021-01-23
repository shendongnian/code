	public static partial class TestClass {
		public static void TestMethod() {
			var internalType=
					typeof(Array).GetNestedType(
						"ArrayEnumerator", BindingFlags.NonPublic);
			var x=new SampleClass();
			var type=x.GetType();
			var bindingAttr=BindingFlags.Instance|BindingFlags.NonPublic;
			var info=type.GetField("dict", bindingAttr);
			var dict=info.GetValue(x) as IDictionary<Type, object>;
			var arrayEnumerator=dict[internalType];
		}
	}
	partial class SampleClass {
		public SampleClass() {
			var internalType=
					typeof(Array).GetNestedType(
						"ArrayEnumerator", BindingFlags.NonPublic);
			var invokeAttr=
					BindingFlags.CreateInstance|
					BindingFlags.Instance|
					BindingFlags.NonPublic;
			var array=new[] { 1, 2, 3 } as IList;
			var args=new object[] { array, 0, array.Count };
			var arrayEnumerator=
					internalType.InvokeMember(
						".ctor", invokeAttr, null, null, args);
			dict.Add(internalType, arrayEnumerator);
		}
		Dictionary<Type, object> dict=new Dictionary<Type, object>();
	}
