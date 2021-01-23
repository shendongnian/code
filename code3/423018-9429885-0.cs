    class Result{
      public String Html{get;set;}
    }
    
    TextReader txtread = new TextReader("page.aspx");
    string text = txtread.ReadToEnd();
    var res = new Result(){Html=text};
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    var json = serializer.Serialize(res);
