       DataTable dt = new DataTable();
        dt.Columns.Add("Gender");
        dt.Columns.Add("Passport");
        dt.Columns.Add("Name");
        foreach (RepeaterItem item in rptemplist.Items)
        {
            TextBox txtGender = (TextBox)item.FindControl("txtGender");
            TextBox txtPassport = (TextBox)item.FindControl("txtPassport");
            TextBox txtName = (TextBox)item.FindControl("txtName");
            dt.Rows.Add(new object[] { txtGender.Text, txtPassport.Text, txtName.Text });
        }
        using (WordprocessingDocument wordDoc2 = WordprocessingDocument.Open(file, true))
        {
            var doc = wordDoc2.MainDocumentPart.Document;
            DocumentFormat.OpenXml.Wordprocessing.Table table = doc.MainDocumentPart.Document.Body.Elements<DocumentFormat.OpenXml.Wordprocessing.Table>().FirstOrDefault();
            int icounterfortableservice;
            for (icounterfortableservice = 0; icounterfortableservice < dt.Rows.Count; icounterfortableservice++)
            {
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                DocumentFormat.OpenXml.Wordprocessing.TableCell tablecellService1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Rows[icounterfortableservice]["Gender"].ToString()))));
                DocumentFormat.OpenXml.Wordprocessing.TableCell tablecellService2 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Rows[icounterfortableservice]["Passport"].ToString()))));
                DocumentFormat.OpenXml.Wordprocessing.TableCell tablecellService3 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Rows[icounterfortableservice]["Name"].ToString()))));
                tr.Append(tablecellService1, tablecellService2, tablecellService3);
                table.AppendChild(tr);
                
            }
        }
