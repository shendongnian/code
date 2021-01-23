    [Export(typeof(IScreen))]
        public class DetailArticleViewModel : Screen
        {
          public List<Article > GeneralList;
          public Article ArticleSelected;
          public BViewModel bw;
    
    
          public DetailArticleViewModel(Article art,List<Article> arts,BViewModel viewmodel)
          {
              ArticleSelected = art;
              GeneralList = arts;
              bw = viewmodel;
          }
    
          // is associated with a button
          public void Save()
          {
              var index = GeneralList.FindIndex(item => item.Code.CompareTo(ArticleSelected.Code)==0);
              GeneralList[index].Price = 900;
              bw.Update(List);
    
          }
    
        }
