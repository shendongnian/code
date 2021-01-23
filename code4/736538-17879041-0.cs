    if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "pdf"))
                        {
                            System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "pdf");
                        }
                        string response;
                        url = "http://google.com";
                        pdfFile = Request.PhysicalApplicationPath + "pdf\\" + speechNumber + ".pdf";
                        //pdfFile = @"D:\\test.pdf";
                        exeFile = Request.PhysicalApplicationPath + "html2pdf\\htmldoc.exe";
                        GeneratePDF gPDF = new GeneratePDF();
                        response = gPDF.ShowPDF(url, pdfFile, exeFile);
                        gPDF = null;
                        if (response == "1")
                        {
                            email.sendMailWithAttachments(txtRecEmail.Text, "", "", txtSenEmail.Text, txtSenName.Text, txtSubject.Text, txtMessage.Text, Request.PhysicalApplicationPath + "pdf\\" + speechNumber + ".pdf", "speech.pdf");
                            Response.Redirect("EmailThanks.aspx?Email=" + txtRecEmail.Text);
                        }
                        else
                        {
                            throw new Exception(response);
                        }
