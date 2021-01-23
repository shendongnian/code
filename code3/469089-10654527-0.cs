    [TestMethod]
    public void Test_because_im_scared() {
        var falseProperty = new TestModel { BooleanProperty = false };
        var trueProperty = new TestModel { BooleanProperty = true };
        var list = new List<TestModel> { falseProperty, trueProperty };
        var results = list.Where(x => (x.IntProperty = 17) == 17) ;
            
        Assert.IsTrue(list.All(itm => itm.IntProperty == 0));
        //all fine so far, now evaluate the results 
        var evaluatedResults = results.ToList();
        Assert.IsTrue(list.All(itm => itm.IntProperty == 0)); // fails here, all 17
            
    }
    private class TestModel {
       public bool BooleanProperty { get; set; }
       public int IntProperty { get; set; }
    }
