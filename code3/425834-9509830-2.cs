    class Article {
        public int ArticleId;
        public string ArticleName;
        // Other fields...
    }
    class ArticleComparer : IEqualityComparer<Article> {
        public bool Equals(Article x, Article y) {
            return x.ArticleId == y.ArticleId && x.ArticleName == y.ArticleName;
        }
        public int GetHashCode(Article obj) {
            return obj.ArticleId.GetHashCode();
        }
    }
    class ArticlesTag {
        public int TagId;
        public int ArticleId;
        // Other fields...
    }
    class Program {
        static void Main(string[] args) {
            // Test data:
            var articles = new[] {
                new Article { ArticleId = 1, ArticleName = "Article A" },
                new Article { ArticleId = 2, ArticleName = "Article B" },
                new Article { ArticleId = 3, ArticleName = "Article C" }
            };
            var article_tags = new[] {
                new ArticlesTag { TagId = 1, ArticleId = 1 },
                new ArticlesTag { TagId = 2, ArticleId = 1 },
                new ArticlesTag { TagId = 3, ArticleId = 1 },
                new ArticlesTag { TagId = 4, ArticleId = 2 },
                new ArticlesTag { TagId = 5, ArticleId = 2 },
                new ArticlesTag { TagId = 6, ArticleId = 3 },
                new ArticlesTag { TagId = 7, ArticleId = 3 }
            };
            var tag_ids = new HashSet<int>(new[] { 2, 3, 6 });
            // JOIN "query":
            var q = (
                from article in articles
                join article_tag in article_tags
                    on article.ArticleId equals article_tag.ArticleId
                where tag_ids.Contains(article_tag.TagId)
                select article
            ).Distinct(new ArticleComparer());
            foreach (var article in q)
                Console.WriteLine(
                    string.Format(
                        "ArticleId = {0}\tArticleName = {1}",
                        article.ArticleId,
                        article.ArticleName
                    )
                );
        }
    }
