    [Test]
    public void Test_Service_Delete() {
        var DatabaseFactory = new OrmLiteConnectionFactory(":memory:", false, SqliteDialect.Provider, true);
        using (var db = DatabaseFactory.OpenDbConnection()) {
            var parentId = db.InsertParam(new ParentObject { name = "Bob" }, true);
            db.Insert(new ChildObject { ParentId = parentId, name = "Sam" });
        
            var service = Container.Resolve<TestService>();
            var response = service.Delete(new DeleteRequestObject(parentId));
    
            Assert.That(db.Select<ParentObject>(parentId), Has.Count.EqualTo(0));
            Assert.That(db.Select<ChildObject>("ParentId = {0}", parentId), Has.Count.EqualTo(0));
        }
    }
