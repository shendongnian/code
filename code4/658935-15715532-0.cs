		partial class SomeClass {
			public T Blah<T>() {
				var t="2013 03 30";
				return (T)(typeof(String).Equals(typeof(T))?t as object:(
					from args in new[] { new object[] { t, default(T) } }
					let type=Nullable.GetUnderlyingType(typeof(T))??typeof(T)
					let types=new[] { typeof(String), type.MakeByRefType() }
					let bindingAttr=BindingFlags.Public|BindingFlags.Static
					let tryParse=type.GetMethod("TryParse", bindingAttr, default(Binder), types, null)
					let b=typeof(DateTime)!=type
					let dummy=b?args[0]=((String)args[0]).Split('\x20').Aggregate(String.Concat):""
					let success=null!=tryParse?tryParse.Invoke(typeof(T), args):false
					select args.Last()).Last());
			}
		}
	<!--->
		partial class TestClass {
			public static void TestMethod() {
				var x=new SomeClass();
				Console.WriteLine("x.Blah<String>() = {0}", x.Blah<String>());
				Console.WriteLine("x.Blah<int>() = {0}", x.Blah<int>());
				Console.WriteLine("x.Blah<DateTime>() = {0}", x.Blah<DateTime>());
				Console.WriteLine("x.Blah<DateTime?>() = {0}", x.Blah<DateTime?>());
				Console.WriteLine("x.Blah<decimal?>() = {0}", x.Blah<decimal?>());
			}
		}
