    [Test]
    public void Test_Service_Delete() {
        var DatabaseFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteDialect.Provider, true);
        int parentId;
        using (var db = DatabaseFactory.OpenDbConnection()) {
            parentId = db.InsertParam(new ParentObject { name = "Bob" }, true);
            db.Insert(new ChildObject { ParentId = parentId, name = "Sam" });
        }
        var service = Container.Resolve<TestService>();
        var response = service.Delete(new DeleteRequestObject(parentId));
        using (var db = DatabaseFactory.OpenDbConnection()) {
            using (var transaction = db.OpenTransaction()) {
                Assert.That(db.Select<ParentObject>(parentId), Has.Count.EqualTo(0));
                Assert.That(db.Select<ChildObject>("ParentId = {0}", parentId), Has.Count.EqualTo(0));
            }
        }
    }
