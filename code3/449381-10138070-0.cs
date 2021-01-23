    [Test]
    public void MyTest()
    {
        using (var documentStore = new EmbeddableDocumentStore { RunInMemory = true })
        {
            documentStore.Initialize();
    
            using (var session = documentStore.OpenSession())
            {
                // test
            }
        }
    }
