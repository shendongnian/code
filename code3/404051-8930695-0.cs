    public class PDFDocumentsBLL {
      private PDFTableAdapter _pdfdocumentsadapter = null;
      public string PDFDB = "PDF_TEMPLATE";
      protected PDFTableAdapter Adapter {
        get {
          if ( _pdfdocumentsadapter == null ) {
            _pdfdocumentsadapter = new PDFTableAdapter();
            
            _pdfdocumentsadapter.Connection = new System.Data.SqlClient.SqlConnection(
              ConfigurationManager.ConnectionStrings["pdf"].ConnectionString.Replace( "PDF_TEMPLATE", PDFDB )
              );
          }
          return _pdfdocumentsadapter;
        }
      }
    }
