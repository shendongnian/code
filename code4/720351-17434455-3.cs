    /// <summary>
    /// Fetches a Web Page
    /// </summary>
    public class WebFetch : System.Web.UI.Page
    {
       protected override void Render(HtmlTextWriter writer)
       {
          // All your code here
          writer.Write(sb.ToString());
       }
    }
