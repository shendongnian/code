    workbook.SaveAs(root + statics + ".xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    
                        // Garbage collecting
                        // Clean up references to all COM objects
                        // As per above, you're just using a Workbook and Excel Application instance, so release them:
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.FinalReleaseComObject(m_objRange);
    
                        Marshal.FinalReleaseComObject(worksheet);
                        workbook.Close(false, Type.Missing, Type.Missing);
                        Marshal.FinalReleaseComObject(workbook);
                        app.Quit();
                        Marshal.FinalReleaseComObject(app);
    
                        MailMessage mm = new MailMessage("def@gmail.com", "xyz@gmail.com", "TestMsg", "Hi");
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = CredentialCache.DefaultNetworkCredentials;
    
                      
                        Attachment data = new Attachment(root + statics + ".xls");
                        mm.Attachments.Add(data);
                        //Now Working Fine:-
                         data.Dispose();
                        client.Send(mm);
    
                        File.Delete(root + statics + ".xls");
