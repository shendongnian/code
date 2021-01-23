    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using iTextSharp.text.pdf;
    using System.Data;
    using System.Text;
    using System.util.collections;
    using iTextSharp.text;
    using System.Net.Mail;
    
    public partial class PDFScenarios : System.Web.UI.Page
    {
    public string P_InputStream = "~/MyPDFTemplates/ex1.pdf";
    public string P_InputStream2 = "~/MyPDFTemplates/ContactInfo.pdf";
    public string P_InputStream3 = "~/MyPDFTemplates/MulPages.pdf";
    public string P_InputStream4 = "~/MyPDFTemplates/CompanyLetterHead.pdf";
    public string P_OutputStream = "~/MyPDFOutputs/ex1_1.pdf";
    
    //Read all 'Form values/keys' from an existing multi-page PDF document
    public void ReadPDFformDataPageWise()
    {
    PdfReader reader = new PdfReader(Server.MapPath(P_InputStream3));
    AcroFields form = reader.AcroFields;
    try
    {
    for (int page = 1; page <= reader.NumberOfPages; page++)
    {
        foreach (KeyValuePair<string, AcroFields.Item> kvp in form.Fields)
        {
            switch (form.GetFieldType(kvp.Key))
            {
                case AcroFields.FIELD_TYPE_CHECKBOX:
                case AcroFields.FIELD_TYPE_COMBO:
                case AcroFields.FIELD_TYPE_LIST:
                case AcroFields.FIELD_TYPE_RADIOBUTTON:
                case AcroFields.FIELD_TYPE_NONE:
                case AcroFields.FIELD_TYPE_PUSHBUTTON:
                case AcroFields.FIELD_TYPE_SIGNATURE:
                case AcroFields.FIELD_TYPE_TEXT:
                    int fileType = form.GetFieldType(kvp.Key);
                    string fieldValue = form.GetField(kvp.Key);
                    string translatedFileName = form.GetTranslatedFieldName(kvp.Key);
                    break;
            }
        }
    }
    }
    catch
    {
    }
    finally
    {
        reader.Close();
    }
    }
    
    //Read and alter form values for only second and 
    //third page of an existing multi page PDF doc.
    //Save the changes in a brand new pdf file.
    public void ReadAlterPDFformDataInSelectedPages()
    {
    PdfReader reader = new PdfReader(Server.MapPath(P_InputStream3));
    reader.SelectPages("1-2"); //Work with only page# 1 & 2
    using (PdfStamper stamper = new PdfStamper(reader, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
    {
        AcroFields form = stamper.AcroFields;
        var fieldKeys = form.Fields.Keys;
        foreach (string fieldKey in fieldKeys)
        {
            //Replace Address Form field with my custom data
            if (fieldKey.Contains("Address"))
            {
                form.SetField(fieldKey, "MyCustomAddress");
            }
        }
        //The below will make sure the fields are not editable in
        //the output PDF.
        stamper.FormFlattening = true;
    }
    }
    
    //Extract text from an existing PDF's second page.
    private string ExtractText()
    {
        PdfReader reader = new PdfReader(Server.MapPath(P_InputStream3));
        string txt =  PdfTextExtractor.GetTextFromPage(reader, 2, new LocationTextExtractionStrategy());
        return txt;
    }
    
    //Create a brand new PDF from scratch and without a template
    private void CreatePDFNoTemplate()
    {
        Document pdfDoc = new Document();
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath(P_OutputStream), FileMode.OpenOrCreate));
    
        pdfDoc.Open();
        pdfDoc.Add(new Paragraph("Some data"));
        PdfContentByte cb = writer.DirectContent;
        cb.MoveTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
        cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
        cb.Stroke();
    
        pdfDoc.Close(); 
    }
    
    private void fillPDFForm()
    {
        string formFile = Server.MapPath(P_InputStream);
        string newFile = Server.MapPath(P_OutputStream);
        PdfReader reader = new PdfReader(formFile);
        using (PdfStamper stamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create)))
        {
            AcroFields fields = stamper.AcroFields;
    
            // set form fields
            fields.SetField("name", "John Doe");
            fields.SetField("address", "xxxxx, yyyy");
            fields.SetField("postal_code", "12345");
            fields.SetField("email", "johndoe@xxx.com");
    
            // flatten form fields and close document
            stamper.FormFlattening = true;
            stamper.Close();
        }
    }
    
    //Helper functions
    private void SendEmail(MemoryStream ms)
    {
        MailAddress _From = new MailAddress("XXX@domain.com");
        MailAddress _To = new MailAddress("YYY@a.com"); 
        MailMessage email = new MailMessage(_From, _To); 
        Attachment attach = new Attachment(ms,  new System.Net.Mime.ContentType("application/pdf")); 
        email.Attachments.Add(attach);  
        SmtpClient mailSender = new SmtpClient("Gmail-Server"); 
        mailSender.Send(email);  
    }
    
    private void DownloadAsPDF(MemoryStream ms)
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment;filename=abc.pdf");
        Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.End();
        ms.Close();
    }
    
    
    //Working with Memory Stream and PDF
    public void CreatePDFFromMemoryStream()
    {
        //(1)using PDFWriter
        Document doc = new Document();
        MemoryStream memoryStream = new MemoryStream();
        PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
        doc.Open();
        doc.Add(new Paragraph("Some Text"));
        writer.CloseStream = false;
        doc.Close();
        //Get the pointer to the beginning of the stream. 
        memoryStream.Position = 0;
        //You may use this PDF in memorystream to send as an attachment in an email
        //OR download as a PDF
        SendEmail(memoryStream);
        DownloadAsPDF(memoryStream);
    
        //(2)Another way using PdfStamper
        PdfReader reader = new PdfReader(Server.MapPath(P_InputStream2));
        using (MemoryStream ms = new MemoryStream())
        {
            PdfStamper stamper = new PdfStamper(reader, ms);
            AcroFields fields = stamper.AcroFields;
            fields.SetField("SomeField", "MyValueFromDB");
            stamper.FormFlattening = true;
            stamper.Close();
            SendEmail(ms);
        }
    }
    
    //Burst-- Make each page of an existing multi-page PDF document 
    //as another brand new PDF document
    private void PDFBurst()
    {
        string pdfTemplatePath = Server.MapPath(P_InputStream3);
        PdfReader reader = new PdfReader(pdfTemplatePath);
        //PdfCopy copy;
        PdfSmartCopy copy;
        for (int i = 1; i < reader.NumberOfPages; i++)
        {
            Document d1 = new Document();
            copy = new PdfSmartCopy(d1, new FileStream(Server.MapPath(P_OutputStream).Replace(".pdf", i.ToString() + ".pdf"), FileMode.Create));
            d1.Open();
            copy.AddPage(copy.GetImportedPage(reader, i));
            d1.Close();
        }
    }
    
     
    
    //Copy a set of form fields from an existing PDF template/doc
    //and keep appending to a brand new PDF file.
    //The copied set of fields will have different values.
    private void AppendSetOfFormFields()
    {
        PdfCopyFields _copy = new PdfCopyFields(new FileStream(Server.MapPath(P_OutputStream), FileMode.Create));
        _copy.AddDocument(new PdfReader(a1("1")));
        _copy.AddDocument(new PdfReader(a1("2")));
        _copy.AddDocument(new PdfReader(new FileStream(Server.MapPath("~/MyPDFTemplates/Myaspx.pdf"), FileMode.Open)));
        _copy.Close();
    }
    //ConcatenateForms
    private byte[] a1(string _ToAppend)
    {
        using (var existingFileStream = new FileStream(Server.MapPath(P_InputStream), FileMode.Open))
        using (MemoryStream stream = new MemoryStream())
        {
            // Open existing PDF
            var pdfReader = new PdfReader(existingFileStream);
            var stamper = new PdfStamper(pdfReader, stream);
            var form = stamper.AcroFields;
            var fieldKeys = form.Fields.Keys;
    
            foreach (string fieldKey in fieldKeys)
            {
                form.RenameField(fieldKey, fieldKey + _ToAppend);
            }
            // "Flatten" the form so it wont be editable/usable anymore
            stamper.FormFlattening = true;
            stamper.Close();
            pdfReader.Close();
            return stream.ToArray();
        }
    }
    
    //Working with Image
    private void AddAnImage()
    {
        using (var inputPdfStream = new FileStream(@"C:\MyInput.pdf", FileMode.Open))
        using (var inputImageStream = new FileStream(@"C:\img1.jpg", FileMode.Open))
        using (var outputPdfStream = new FileStream(@"C:\MyOutput.pdf", FileMode.Create))
        {
            PdfReader reader = new PdfReader(inputPdfStream);
            PdfStamper stamper = new PdfStamper(reader, outputPdfStream);
            PdfContentByte pdfContentByte = stamper.GetOverContent(1);
            var image = iTextSharp.text.Image.GetInstance(inputImageStream);
            image.SetAbsolutePosition(1, 1);
            pdfContentByte.AddImage(image);
            stamper.Close();
        }
    
    }
    
    //Add Company Letter-Head/Stationary to an existing pdf
    private void AddCompanyStationary()
    {
        PdfReader reader = new PdfReader(Server.MapPath(P_InputStream2));
        PdfReader s_reader = new PdfReader(Server.MapPath(P_InputStream4));
    
        using (PdfStamper stamper = new PdfStamper(reader, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
        {
            PdfImportedPage page = stamper.GetImportedPage(s_reader, 1);
            int n = reader.NumberOfPages;
            PdfContentByte background;
            for (int i = 1; i <= n; i++)
            {
                background = stamper.GetUnderContent(i);
                background.AddTemplate(page, 0, 0);
            }
            stamper.Close();
        }
    }
   
