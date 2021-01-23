    class MyPage: Page
    {
        private IList<int> correctAnswers;
        private readonly string cacheKey = "cachedResults";
    
        protected void Page_Load(object sender, EventARgs args)
        {
           this.LoadCache();
        }
    
        protected void rbAnswers_SelectedIndexChanged(object sender, EventArgs e)    
        {               
            if (rbAnswers.SelectedIndex >= 0)
            {
               // TODO: ensure there are enough allocated items
               // so indexer [] would not throw
               correctAnswers[rbAnswers.SelectedIndex] = i; 
               this.SyncCache();
            }
        }
    
        private LoadCache()
        {
           var resultsCache = Session[this.cacheKey];
           if (resultsCache != null)
           {
              this.correctAnswers = resultsCache as List<int>;
           }
        }
    
        private void SyncCache()
        {
            Session[this.cacheKey] = this.correctAnswers;
        }  
    }
