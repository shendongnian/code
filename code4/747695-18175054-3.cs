    [TestMethod]
        public void BaseRepositoryPagingTest() {
            var luw = new LuwMaster();
            var someMore = true;
            var skip = 0;
            var take = 3;
            while (someMore) {
                var mimeList = luw.GetRepository<MimeType>().GetSortedPageList(m => true, m => m.Id, true, skip, take);
                someMore = false;
                foreach (var mimeType in mimeList) {
                    Debug.WriteLine( mimeType.MimeTypeCategory + ", " + mimeType.Id);
                    someMore = true;
                }
                skip = skip + take;
            }
        }
