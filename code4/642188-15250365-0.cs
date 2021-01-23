    public class MyNewExtended: MyNew {
       public String Tel { get;set; }
    }
    
    var myList = myPage.News.Cast<MyNewExtended>();
