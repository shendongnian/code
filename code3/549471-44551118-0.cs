	private class Person {
		[CustomAttribute1]
		public virtual String Name { get; set; }
	}
	private class Person2 : Person {
		[CustomAttribute2]
		public override String Name { get; set; }
	}
	public static void TestMemberInfoEquality() {
		MemberInfo m1 = ExpressionEx.GetMemberInfo<Person>(p => p.Name);
		MemberInfo m2 = ExpressionEx.GetMemberInfo<Person2>(p => p.Name);
		bool b1 = m1.MetadataToken == m2.MetadataToken; // false
		bool b2 = m1 == m2; // false (because ReflectedType is different)
		bool b3 = m1.DeclaringType == m2.DeclaringType; // false
		bool b4 = AreEqual1(m1, m2); // false
		bool b5 = AreEqual2(m1, m2); // false
		bool b6 = AreEqual3(m1, m2); // true
	}
	public static bool AreEqual1(MemberInfo m1, MemberInfo m2) {
		return m1.MetadataToken == m2.MetadataToken && m1.Module == m2.Module;
	}
	public static bool AreEqual2(MemberInfo m1, MemberInfo m2) {
		return m1.DeclaringType == m2.DeclaringType && m1.Name == m2.Name;
	}
	public static bool AreEqual3(MemberInfo m1, MemberInfo m2) {
		return m1.GetRootDeclaration() == m2.GetRootDeclaration();
	}
	public static MemberInfo GetRootDeclaration(this MemberInfo mi) {
		Type ty = mi.ReflectedType;
		while (ty != null) {
			MemberInfo[] arr = ty.GetMember(mi.Name, mi.MemberType, BindingFlags.Instance | BindingFlags.Public);
			if (arr == null || arr.Length == 0)
				break;
			mi = arr[0];
			ty = ty.BaseType;
		}
		return mi;
	}
