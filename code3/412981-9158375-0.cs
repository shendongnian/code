    public abstract class PageBase
    {
         protected Type PageType { get; private set; }
         protected override void OnInit(EventArgs e)
         {
            PageType = Business.GetPageType();
         } 
    }
