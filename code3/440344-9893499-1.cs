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
            int j = rbAnswers.SelectedIndex;
            if (j >=0)
            {
               correctAnswers[j] = i; 
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
