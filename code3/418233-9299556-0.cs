    public ButtonHelper
    {
       public string Text {get; set;}
       public MvcHtmlString Grey()
       {
          return MvcHtmlString.Create("<button class='grey'>"+ Text +"</button>");
       }
    }
    
    public static class Buttons
    {
       public static ButtonHelper Button(this HtmlHelper, string text)
       {
          return new ButtonHelper{Text = text};
       }
    }
