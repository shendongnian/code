            // if object has been loaded, load will return real instance
            using (var session = CreateSession())
            {
                postByGet = session.Get<Post>(post1Id);
                postByLoad = session.Load<Post>(post1Id);
                Assert.IsFalse(postByGet is INHibernateProxy);
                Assert.IsFalse(postByLoad is INHibernateProxy);
                Assert.IsTrue(object.ReferenceEquals(postByGet, postByLoad));
            }
            // if proxy has been loaded, get will return filled proxy
            using (var session = CreateSession())
            {
                postByLoad = session.Load<Post>(post1Id);
                postByGet = session.Get<Post>(post1Id);
                Assert.IsTrue(postByGet is INHibernateProxy);
                Assert.IsTrue(postByLoad is INHibernateProxy);
                Assert.IsTrue(object.ReferenceEquals(postByGet, postByLoad));
            }
