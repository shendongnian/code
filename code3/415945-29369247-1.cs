    using (FileStream msReport = new FileStream(pdfPath, FileMode.Create))
            {
                using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    try
                    {
                        //open the stream 
                        pdfDoc.Open();
    					pdfDoc.setMargin(20f, 20f, 20f, 20f);
                        pdfDoc.NewPage();
                        
                        pdfDoc.Close();
    
                    }
                    catch (Exception ex)
                    {
                        //handle exception
                    }
    
                    finally
                    {
    
    
                    }
    
                }
    
            }
