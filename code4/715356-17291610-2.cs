	object b = 2;
	if (TestClass.<TestMethod>o__SiteContainer0.<>p__Site1 == null)
	{
		TestClass.<TestMethod>o__SiteContainer0.<>p__Site1 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Take", null, typeof(TestClass), new CSharpArgumentInfo[]
		{
			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
			CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
		}));
	}
	TestClass.<TestMethod>o__SiteContainer0.<>p__Site1.Target(TestClass.<TestMethod>o__SiteContainer0.<>p__Site1, typeof(TestClass), b);
