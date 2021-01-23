    public class Class1
    {
      public HtmlGenericControl FindDiv(Page page)
     { 
        HtmlGenericControl step1 = (HtmlGenericControl)page.FindControl("step1");
        return step1;
     }
    }
