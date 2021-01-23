    // Create a class that implements IDisposable so when the writer closes the
    // @using statement, the end tags are output to.
    public class HtmlWidget : IDisposable
    {
      #region CTor
      // store some references for ease of use
      private readonly ViewContext viewContext;
      private readonly TextWriter textWriter;
      // Initialize the box by passing it the view context (so we can
      // reference the stream writer) Then call the BeginWidget method
      // to begin the output of the widget
      public HtmlBox(ViewContext viewContext, String title, Int32 columnWidth = 6)
      {
        if (viewContext == null)
          throw new ArgumentNullException("viewContext");
        if (String.IsNullOrWhiteSpace(title))
          throw new ArgumentNullException("title");
        if (columnWidth < 1 || columnWidth > 12)
          throw new ArgumentoutOfRangeException("columnWidth", "Value must be from 1-12");
        this.viewContext = viewContext;
        this.textWriter = this.viewContext.Writer;
        this.BeginWidget(title, columnWidth);
      }
      #endregion
      #region Widget rendering
      // outputs the opening HTML for the widget
      protected virtual void BeginWidget(String title, Int32 columnWidth)
      {
        title = HttpUtility.HtmlDecode(title);
        var html = new System.Text.StringBuilder();
        html.AppendFormat("<div class=\"box grid_{0}\">", columnWidth).AppendLine();
        html.AppendFormat("<div class=\"box-head\">{0}</div>", title).AppendLine();
        html.Append("<div class="box-content">").AppendLine();
        this.textWriter.WriteLine(html.ToString());
      }
      // outputs the closing HTML for the widget
      protected virtual void EndWidget()
      {
        this.textWriter.WriteLine("</div></div>");
      }
      #endregion
      #region IDisposable
      private Boolean isDisposed;
      public void Dispose()
      {
        this.Dispose(true);
        GC.SuppressFinalize(this);
      }
      public virtual void Dispose(Boolean disposing)
      {
        if (!this.isDisposed)
        {
          this.Endwidget();
          this.isdisposed = true;
        }
      }
      #endregion
    }
