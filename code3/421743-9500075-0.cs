    using System;
    using System.IO;
    using System.Diagnostics;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    public class iTextDemo 
    {
     public static void Main() 
     {
      Console.WriteLine("iText Demo");
    
      // step 1: creation of a document-object
      Document myDocument = new Document(PageSize.A4.Rotate());
    
      try 
      {
    
       // step 2:
       // Now create a writer that listens to this doucment and writes the document to desired Stream.
    
       PdfWriter.GetInstance(myDocument, new FileStream("Salman.pdf", FileMode.Create));
    
       // step 3:  Open the document now using
       myDocument.Open();
    
       // step 4: Now add some contents to the document
       myDocument.Add(new Paragraph("First Pdf File made by Salman using iText"));
    
      }
      catch(DocumentException de) 
      {
       Console.Error.WriteLine(de.Message);
      }
      catch(IOException ioe) 
      {
       Console.Error.WriteLine(ioe.Message);
      }
    
      // step 5: Remember to close the documnet
    
      myDocument.Close();
     }
    }
