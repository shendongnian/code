    Using Rotativa;
    
    ...
    
    byte[] pdfByteArray = Rotativa.WkhtmltopdfDriver.ConvertHtml( "Rotativa", "-q", stringHtmlResult );
    
    File.WriteAllBytes( outputPath, pdfByteArray );
