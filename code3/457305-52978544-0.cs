    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.tool.xml;
    namespace ExampleOfExportingPDF
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Build HTML document
                StringBuilder sb = new StringBuilder();
                sb.Append("<body>");
                sb.Append("<h1 style=\"text-align:center;\">これは日本語のテキストの例です。</h1>");
                sb.Append("</body>");
                //Create our document object
                Document Doc = new Document(PageSize.A4);
                //Create our file stream
                using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    //Bind PDF writer to document and stream
                    PdfWriter writer = PdfWriter.GetInstance(Doc, fs);
                    //Open document for writing
                    Doc.Open();
                    //Add a page
                    Doc.NewPage();
                    MemoryStream msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, Doc, msHtml, null, Encoding.UTF8, new UnicodeFontFactory());
                    //Close the PDF
                    Doc.Close();
                }
            }
            public class UnicodeFontFactory : FontFactoryImp
            {
                private static readonly string FontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
              "arialuni.ttf");
                private readonly BaseFont _baseFont;
                public UnicodeFontFactory()
                {
                    _baseFont = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
                public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color,
              bool cached)
                {
                    return new Font(_baseFont, size, style, color);
                }
            }
        }
    }
