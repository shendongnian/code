    public class YourDataPager : DataPager
    {
       protected override HtmlTextWriterTag TagKey 
       {
          get { return HtmlTextWriterTag.Div; }
       }
    }
