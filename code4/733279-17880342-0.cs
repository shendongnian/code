          public bool Active
        {
            get
            {
                if (this.Article != null)
                {
                    return (this.Article.Status == NewsArticleStatus.Active);
                }
                return false;
            }
            set
            {
                if (this.Article != null)
                {
                    this.Article.Status = (value ? NewsArticleStatus.Active : NewsArticleStatus.Inactive);
                }
            }
        }  
