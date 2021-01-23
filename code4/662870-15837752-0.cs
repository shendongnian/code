        [Export(typeof(IScreen))]
        public class BViewModel : Screen
        {
                private List<Article> articles;
                public List<Article> Articles
                {
                    get
                    {
                        return this.articles;
                    }
        
                    private set
                    {
                        if (this.articles == value)
                        {
                            return;
                        }
        
                        this.articles = value;
                        this.NotifyOfPropertyChange(() => this.Articles);
                    }
                }
        
           public BolleViewModel()
           {
             Articles = recoverArticles(); //returns a list of articles
           }
    
    
           public void Update(List<Article> list)
           {
                   Articles = list;
           }
    
            //is associated with a button
            public void Detail()
            {
                if(SelectedArticle!=null)
                    WindowManager.ShowWindow(new DetailArticleViewModel(SelectedArticle, Articles), null, null);
                else
                {
                    MessageBox.Show("Select an article","Error!",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
       }
