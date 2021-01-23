    var dataContext = new DataContext();
    var testEntity = new TestEntity { Message = "Test message" };
    var related = new RelatedTest { Something = true };
    testEntity.RelatedTests = new List<RelatedTest>{related};
    dataContext.TestEntities.Add(testEntity);
    dataContext.SaveChanges();
