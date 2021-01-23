        private static Object LockObject = new object();
        public void TestMethod1()
        {
            lock(LockObject)
            {
                Object1.StaticMember = 1;
                Object2 test = new Object2();
                Assert.AreEqual("1", test.getStaticVal());
            }
        }
        public void TestMethod2()
        {
            lock (LockObject)
            {
                Object1.StaticMember = 2;
                Object2 test = new Object2();
                Assert.AreEqual("2", test.getStaticVal());
            }
        }
