        [TestMethod]
        public void Unit_Can_Add_Two_Numbers()
        {
            UnitTestUtilities.DataDrivenTest(
                dataRow =>
                {
                    // Tests a+b=c
                    var a = (int)dataRow[0];
                    var b = (int)dataRow[1];
                    var c = (int)dataRow[2];
                    Assert.AreEqual(a + b, c);
                },
                new List<List<object>>
                    {
                        // Rows of arguments a,b,c respectively
                        new List<object>{1,2,3},
                        new List<object>{4,5,9}
                    });
        }
