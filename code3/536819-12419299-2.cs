    //class for holding relation between the code and page name 
    public class Data 
    {
       public string Code {get;set;}
       public string PageName {get;set;}
    }
    var dic = new Dictionary<string, Data >{ 
                 {"A", new Data{Code="0001000", PageName = "Article"}, 
                 {"F", newe Data{Code="0002000", PageName="FavoritesList"}
    }
