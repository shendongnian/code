		public abstract class BaseClass {
			protected static void Register<U>(String identifier) where U : BaseClass {
				m_identities.Add(typeof(U).GetHashCode(), identifier);
			}
			public static String GetIdentifier<U>() where U : BaseClass {
				var t = typeof(U);
				var identifier = default(String);
				RuntimeHelpers.RunClassConstructor(t.TypeHandle);
				m_identities.TryGetValue(t.GetHashCode(), out identifier);
				return identifier;
			}
			static Dictionary<int, String> m_identities = new Dictionary<int, String> { };
		}
		public class DerivedClassA:BaseClass {
			static DerivedClassA() {
				BaseClass.Register<DerivedClassA>("12dc2490-065d-449e-a199-6ba051c93622");
			}
		}
		public class DerivedClassB:BaseClass {
			static DerivedClassB() {
				BaseClass.Register<DerivedClassB>("9745e24a-c38b-417d-a44d-0717e10e3b96");
			}
		}
	--- 
	test: 
		Debug.Print("{0}", BaseClass.GetIdentifier<DerivedClassA>());
		Debug.Print("{0}", BaseClass.GetIdentifier<DerivedClassB>());
