        public class News
        {
            public DateTime? NewsDate;
            public DateTime? CreationDate;
            public string Name;
            public News(string name, DateTime? newsDate, DateTime? creationDate) { this.Name = name; this.NewsDate = newsDate; this.CreationDate = creationDate; }
        }
        [TestMethod()]
        public void NewsTestOrderBy()
        {
            var news1 = new News("newsitem1", new DateTime(2012, 8, 3), new DateTime(2012, 8, 7));
            var news2 = new News("newsitem2", null, new DateTime(2012, 8, 7));
            var news3 = new News("newsitem3", new DateTime(2012, 7, 25), new DateTime(2012, 8, 7));
            var news = new List<News>() { news1, news2, news3 };
            var orderedNews = news.OrderByDescending(t => t.NewsDate.HasValue ? t.NewsDate : t.CreationDate).ToList();
            Assert.AreEqual(news2, orderedNews[0]);
            Assert.AreEqual(news1, orderedNews[1]);
            Assert.AreEqual(news3, orderedNews[2]);
        }
