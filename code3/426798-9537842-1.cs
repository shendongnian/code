        [TestMethod]
        public void TestMethod1()
        {
            var someClassInstance1 = new ClassA();
            var someClassInstance2 = new ClassA();
            var mainSettings = new Settings
                {
                    SomeInt = 1, 
                    SomeString = "2", 
                    SomeObject = true, 
                    SomeClass = someClassInstance1,
                    SomeArray = new[] { false }
                };
            var refToMainSettings = mainSettings;
            var dialogSettings = new Settings
                {
                    SomeInt = 2,
                    SomeString = "3",
                    SomeObject = 1.0,
                    SomeClass = someClassInstance2,
                    SomeArray = new[] { true, false }
                };
            // The magic method :-)
            PropertyUpdater.Update(mainSettings).With(dialogSettings);
            Assert.AreSame(refToMainSettings, mainSettings);
            Assert.AreEqual(2, mainSettings.SomeInt);
            Assert.AreEqual("3", mainSettings.SomeString);
            Assert.IsInstanceOfType(mainSettings.SomeObject, typeof(double));
            Assert.AreEqual(1.0, mainSettings.SomeObject);
            Assert.AreSame(someClassInstance2, mainSettings.SomeClass);
            Assert.AreEqual(2, mainSettings.SomeArray.Length);
            Assert.AreEqual(true, mainSettings.SomeArray[0]);
            Assert.AreEqual(false, mainSettings.SomeArray[1]);
        }
        public class Settings
        {
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
            public object SomeObject { get; set; }
            public ClassA SomeClass { get; set; }
            public bool[] SomeArray { get; set; }
            public bool this[int i]
            {
                get { return SomeArray[i]; }
                set { SomeArray[i] = value; }
            }
        }
        public class ClassA {}
