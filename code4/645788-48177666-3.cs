		public abstract class BaseClass {
			public abstract String Identifier {
				get;
			}
			public static Type GetDerivedClass(String identifier) {
				return m_aliases[identifier];
			}
			public static String GetIdentifier(Type t) {
				var value = default(String);
				if(t.IsSubclassOf(typeof(BaseClass))) {
					var key = t.GetHashCode();
					if(!m_identities.TryGetValue(key, out value)) {
						value=""+key;
						m_aliases.Add(value, t);
						m_identities[key]=value;
					}
				}
				return value;
			}
			static void UpdateAlias(BaseClass x) {
				var t = x.GetType();
				var value = x.Identifier;
				m_aliases.Add(value, t);
				m_identities[t.GetHashCode()]=value;
			}
			protected BaseClass() {
				BaseClass.UpdateAlias(this);
			}
			static Dictionary<String, Type> m_aliases = new Dictionary<String, Type> { };
			static Dictionary<int, String> m_identities = new Dictionary<int, String> { };
		}
	---
		public class DerivedClassA:BaseClass {
			public override String Identifier {
				get {
					return "just text";
				}
			}
		}
		public class DerivedClassB:BaseClass {
			public override String Identifier {
				get {
					return "just text";
				}
			}
		}
	--- 
	and the test: 
		public static void TestMethod() {
			var idBeforeInstantiation = BaseClass.GetIdentifier(typeof(DerivedClassA));
			var y = new DerivedClassA { };
			var idAfterInstantiation = BaseClass.GetIdentifier(typeof(DerivedClassA));
			Debug.Print("B's: {0}", BaseClass.GetIdentifier(typeof(DerivedClassB)));
			Debug.Print("A's after: {0}", idAfterInstantiation);
			Debug.Print("A's before: {0}", idBeforeInstantiation);
			Debug.Print("A's present: {0}", BaseClass.GetIdentifier(typeof(DerivedClassA)));
			var type1 = BaseClass.GetDerivedClass(idAfterInstantiation);
			var type2 = BaseClass.GetDerivedClass(idBeforeInstantiation);
			Debug.Print("{0}", type2==type1); // true
			Debug.Print("{0}", type2==typeof(DerivedClassA)); // true
			Debug.Print("{0}", type1==typeof(DerivedClassA)); // true
			var typeB=BaseClass.GetDerivedClass(BaseClass.GetIdentifier(typeof(DerivedClassB)));
			var x = new DerivedClassB { }; // confilct
		}
