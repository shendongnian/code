    internal class DocumentEvents : PdfPageEventHelper
    {
        /// <summary>
        /// Called when [start page].
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="document">The document.</param>
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            if (document.PageNumber == 1)
            {
                document.SetMargins(40f, 40f, 130f, 20f);
            }
            else
            {
                document.SetMargins(40f, 40f, 30f, 30f);
            }
            document.NewPage();
        }
    }
