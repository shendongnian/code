    public class UnorderedListDataPager : DataPager
    {
       protected override HtmlTextWriterTag TagKey 
       {
          get { return HtmlTextWriterTag.Ul; }
       }
       
       protected override void RenderContents(HtmlTextWriter writer)
       {
          if (HasControls())
          {
             foreach (Control child in Controls)
             {
                var item = child as DataPagerFieldItem;
                if (item == null || !item.HasControls())
                {
                    child.RenderControl(writer);
                    continue;
                }
                
                foreach (Control button in item.Controls)
                {
                   var space = button as LiteralControl;
                   if (space != null && space.Text == "&nbsp;") continue;
                   
                   writer.RenderBeginTag(HtmlTextWriterTag.Li);
                   button.RenderControl(writer);
                   writer.RenderEndTag();
                }
             }
          }
       }
    }
