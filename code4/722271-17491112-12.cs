    public class ArticlesProxy : Articles, IInterface 
    {
      public ArticlesProxy(string name) : base(name){}
      
    }
    
    public class QuestionaireProxy : Questionaire, IInterface {
      Questionaire inner;
      public QuestionaireProxy(string name) {  inner = new Questionaire(name); }
      
      public void Output() { inner.Output();}
      
    }
