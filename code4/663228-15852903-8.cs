        [AssemblyInitialize]
        public static void TestInitialize(TestContext pContext)
        {
            XHelper.ClientTypes = new Type[] { typeof(Thing1ProxyAtClient), typeof(Thing2ProxyAtClient), typeof(Thing2ProxyAtClient) };
            XHelper.ServerTypes = new Type[] { typeof(Thing1ProxyAtServer), typeof(Thing2ProxyAtServer), typeof(ThingNProxyAtServer) };
        }
