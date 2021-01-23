        [TestMethod]
        public void DynamicTest()
        {
            List<DataObject> dataObjects = new List<DataObject>();
            dynamic firstObject = new DataObject();
            dynamic secondObject = new DataObject();
            firstObject.dblProp = 10.0;
            firstObject.intProp = 8;
            firstObject.strProp = "Hello";
            secondObject.dblProp = 8.0;
            secondObject.intProp = 8;
            secondObject.strProp = "World";
            dataObjects.Add(firstObject);
            dataObjects.Add(secondObject);
             
            /* Notice the different types */
            string newQuery = FormatQuery("dblProp > 9.0 AND intProp = 8 AND strProp = 'Hello'");
            var result = dataObjects.Where(newQuery);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result.First(), firstObject);
        }
