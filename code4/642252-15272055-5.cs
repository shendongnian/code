    [TestMethod]
    public void SubjectTestWithCollections()
    {
        var list1 = new List<Subject>() { new Subject(1), new Subject(2) };
        var list2 = new List<Subject>() { new Subject(1), new Subject(2) };
        CollectionAssert.AreEqual(list1, list2);
    }
