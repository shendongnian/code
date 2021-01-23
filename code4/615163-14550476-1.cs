    private Db CreateDb() {
        return Db.Create("R:\\"+TestContext.FullyQualifiedTestClassName + 
                         TestContext.TestName + ".sdf");
    }
    [TestMethod]
    public void StoreAndRetrieve() {
        using (var db = CreateDb()) {
            ...
        }
    }
