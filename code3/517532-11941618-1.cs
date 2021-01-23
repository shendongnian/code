     using (ISession session = SessionFactory.Factory.OpenSession())
            {
                int someId = 329;
                Person p = session.Get<Person>(someId);
                Person test = new Person() { BusinessEntityID = someId };
                Assert.IsTrue(p.Equals(test)); //your code might think the objects are equal, so you'd probably expect the next line to return true         
                
                Assert.IsFalse(session.Contains(test)); //But they're not the same object
                Assert.Throws<NonUniqueObjectException>(() =>
                {
                    session.Lock(test, LockMode.None); //So when you ask nhibernate to track changes on both objects, it gets very confused
                });
            }
