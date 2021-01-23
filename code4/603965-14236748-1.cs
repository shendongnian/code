    /// <summary>
    /// Widget container
    /// </summary>
    /// <remarks>
    /// We make it IDIsposable so we can use it like Html.BeginForm and when the @using(){} block has ended,
    /// the end of the widget's content is output.
    /// </remarks>
    public class HtmlWidget : IDisposable
    {
        #region CTor
        // store some references for ease of use
        private readonly ViewContext viewContext;
        private readonly System.IO.TextWriter textWriter;
        /// <summary>
        /// Initialize the box by passing it the view context (so we can
        /// reference the stream writer) Then call the BeginWidget method
        /// to begin the output of the widget
        /// </summary>
        /// <param name="viewContext">Reference to the viewcontext</param>
        /// <param name="title">Title of the widget</param>
        /// <param name="columnWidth">Width of the widget (column layout)</param>
        public HtmlWidget(ViewContext viewContext, String title, Int32 columnWidth = 6)
        {
            if (viewContext == null)
                throw new ArgumentNullException("viewContext");
            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title");
            if (columnWidth < 1 || columnWidth > 12)
                throw new ArgumentOutOfRangeException("columnWidth", "Value must be from 1-12");
            this.viewContext = viewContext;
            this.textWriter = this.viewContext.Writer;
            this.BeginWidget(title, columnWidth);
        }
        #endregion
        #region Widget rendering
        /// <summary>
        /// Outputs the opening HTML for the widget
        /// </summary>
        /// <param name="title">Title of the widget</param>
        /// <param name="columnWidth">Widget width (columns layout)</param>
        protected virtual void BeginWidget(String title, Int32 columnWidth)
        {
            title = HttpUtility.HtmlDecode(title);
            var html = new System.Text.StringBuilder();
            html.AppendFormat("<div class=\"box grid_{0}\">", columnWidth).AppendLine();
            html.AppendFormat("<div class=\"box-head\">{0}</div>", title).AppendLine();
            html.Append("<div class=\"box-content\">").AppendLine();
            this.textWriter.WriteLine(html.ToString());
        }
        /// <summary>
        /// Outputs the closing HTML for the widget
        /// </summary>
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
                this.EndWidget();
                this.textWriter.Flush();
                this.textWriter = null;
                this.viewContext = null;
                this.isDisposed = true;
            }
        }
        #endregion
    }
