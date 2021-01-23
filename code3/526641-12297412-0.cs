        [TestMethod]
        public void TestWithZeroSizedArray()
        {
            string jsCode = @"myArray.length;";
            var javascriptEngine = new IronJS.Hosting.CSharp.Context();
            var array = new ArrayObject(javascriptEngine.Environment, 0); // Creates a 0-sized Array
            array.Put(0, 12.0);
            array.Put(1, 45.1);
            javascriptEngine.SetGlobal<ArrayObject>("myArray", array);
            var result = javascriptEngine.Execute(jsCode);
            Assert.AreEqual(2, result);
        }
