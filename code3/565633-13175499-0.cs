    string pdfFile = "c:\\CrytalReport.pdf";
    
    protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = pdfFile;
                CrExportOptions = ReportDocument .ExportOptions;//Report document  object has to be given here
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                ReportDocument .Export();
    
                sendmail();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
    
        }
        private void sendmail()
        {
            try
            {
               
                MailMessage Msg = new MailMessage();
                Msg.To = "to Address";
                Msg.From = "From Address";
                Msg.Subject = "Crystal Report Attachment ";
                Msg.Body = "Crystal Report Attachment ";
                Msg.Attachments.Add(new MailAttachment(pdfFile));
               // System.Web.Mail.SmtpMail.Send(Msg);
    
                SmtpMail.SmtpServer = "you mail domain";
                //SmtpMail.SmtpServer.Insert(0,"127.0.0.1");
    
                SmtpMail.Send(Msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    
    Dont forget add these DLL's
    
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    
     
    
    Hope this helps !!!!!!!!!!!!!
