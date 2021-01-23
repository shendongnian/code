    public void ShoulHaveAllDataInWhenIdIsNotSpecifiedID()
    {
       MyClass logic = new MyClass();   
       logic.SpecifiedID = 3;
    
       logic.DataIn(1,"2"); 
       logic.DataIn(2,"4");     
       CollectionAssert.AreEqual(new[] { "2", "4" }, logic.Expected);
    }
    [Test]
    public void ShoulClearAllDataWhenSpecifiedIDPassed()
    {
       MyClass logic = new MyClass();   
       logic.SpecifiedID = 3;
    
       logic.DataIn(1,"2"); 
       logic.DataIn(2,"4"); 
       logic.DataIn(3,"6");     
       CollectionAssert.AreEqual(new[] { }, logic.Expected);
    }
