            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
           
                wordDocument = word.Documents.Open(savedFileName, ReadOnly: true);
                wordDocument.ExportAsFixedFormat(attahcmentPath + "/pdf" + attachment.BetAttachmentCode + ".pdf", Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
              
            word.Quit(false);
