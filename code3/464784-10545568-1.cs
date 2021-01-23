       [Test, TestCaseSource("GetTestData")]
        public void MyExample_Test(int data1, int data2, int expectedOutput)
        {
            var methodOutput = MethodUnderTest(data2, data1);
            Assert.AreEqual(expectedOutput, methodOutput, string.Format("Method failed for data1: {0}, data2: {1}", data1, data2));
        }
        private IEnumerable<int[]> GetTestData()
        {
             while (data.ReadNext()) // Use your custom logic based on Stream to get new data (basically Implement IEnumerator on data class)
              yield return new[] { data.Current };
        }
