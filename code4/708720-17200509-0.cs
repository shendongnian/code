        [Test]
        public void Test()
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(new Parent {Inner = new Child {Num = 1}});
                session.SaveChanges();
            }
            using (var session = DocumentStore.OpenSession())
            {
                var list = session.Advanced.LuceneQuery<Parent>()
                       .WhereEquals(x => x.Inner.Num, 1)
                       .ToList();
                Assert.That(list.Count, Is.EqualTo(1));
            }
        }
