    /// <summary>
    ///This is a test class for CoreUtilsTest and is intended
    ///to contain all CoreUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CoreUtilsTest
    {
        /// <summary>
        /// A class to perform testing on.
        /// </summary>
        public class MyClassA
        {
            public string Param1;
            public string Param2;
            public string Param3;
        }
        /// <summary>
        /// A class to perform testing on.
        /// </summary>
        public class MyClassB
        {
            private string _param1;
            public string Param1
            {
                get { return _param1; }
                set { _param1 = value; }
            }
            private string _param2;
            public string Param2
            {
                get { return _param2; }
                set { _param2 = value; }
            }
            private string _param3;
            public string Param3
            {
                get { return _param3; }
                set { _param3 = value; }
            }
        }
        /// <summary>
        ///A test for SetProperties
        ///</summary>
        [TestMethod()]
        public void Merging_Fields()
        {
            MyClassA defaults = new MyClassA { Param1 = "defaults" };
            MyClassA settings = new MyClassA { Param2 = "settings" };
            MyClassA results = CoreUtils.ObjectMerge<MyClassA>(defaults, settings);
            Assert.AreEqual("defaults", results.Param1);
            Assert.AreEqual("settings", results.Param2);
            Assert.AreEqual(null, results.Param3);
        }
        [TestMethod()]
        public void Merging_Properties()
        {
            MyClassB defaults = new MyClassB { Param1 = "defaults" };
            MyClassB settings = new MyClassB { Param2 = "settings" };
            MyClassB results = CoreUtils.ObjectMerge<MyClassB>(defaults, settings);
            Assert.AreEqual("defaults", results.Param1);
            Assert.AreEqual("settings", results.Param2);
            Assert.AreEqual(null, results.Param3);
        }
    }
