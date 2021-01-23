    using System;
    using System.IO;
    
    namespace PdfSharp.Pdf.IO
    {
        static public class CompatiblePdfReader
        {
            /// <summary>
            /// uses itextsharp 4.1.6 to convert any pdf to 1.4 compatible pdf, called instead of PdfReader.open
            /// </summary>
            static public PdfDocument Open(string pdfPath)
            {
                using (var fileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read))
                {
                    var len = (int)fileStream.Length;
                    var fileArray = new Byte[len];
                    fileStream.Read(fileArray, 0, len);
                    fileStream.Close();
    
                    return Open(fileArray);
                }
            }
    
            /// <summary>
            /// uses itextsharp 4.1.6 to convert any pdf to 1.4 compatible pdf, called instead of PdfReader.open
            /// </summary>
            static public PdfDocument Open(byte[] fileArray)
            {
                return Open(new MemoryStream(fileArray));
            }
    
            /// <summary>
            /// uses itextsharp 4.1.6 to convert any pdf to 1.4 compatible pdf, called instead of PdfReader.open
            /// </summary>
            static public PdfDocument Open(MemoryStream sourceStream)
            {
                PdfDocument outDoc;
                sourceStream.Position = 0;
    
                try
                {
                    outDoc = PdfReader.Open(sourceStream, PdfDocumentOpenMode.Import);
                }
                catch (PdfReaderException)
                {
                    //workaround if pdfsharp doesn't support this pdf
                    sourceStream.Position = 0;
                    var outputStream = new MemoryStream();
                    var reader = new iTextSharp.text.pdf.PdfReader(sourceStream);
                    var pdfStamper = new iTextSharp.text.pdf.PdfStamper(reader, outputStream) {FormFlattening = true};
                    pdfStamper.Writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_4);
                    pdfStamper.Writer.CloseStream = false;
                    pdfStamper.Close();
    
                    outDoc = PdfReader.Open(outputStream, PdfDocumentOpenMode.Import);
                }
    
                return outDoc;
            }
        }
    }
