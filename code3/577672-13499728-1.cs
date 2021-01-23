    [Test]
    [TestCaseSource("GetTestCases")]
    public void TestMethod(MyObject1 param1, MyObject2 param2){
       // run your test with those parameters
    }
    
    private IEnumerable GetTestCases(){
       yield return new TestCaseData( new MyObject1("first test args"), 
                                      new MyObject2("first test args"))
                            .SetName("SomeMeaningfulNameForThisTestCase" );
       yield return new TestCaseData( new MyObject1("2nd test args"), 
                                      new MyObject2("2nd test args"))
                            .SetName("SomeMeaningfulNameForThisTestCase2" );
    			
    }
