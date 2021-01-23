    Using Rotativa;
    
    ...
    
    byte[] pdfByteArray = Rotativa.WkhtmltopdfDriver.ConvertHtml( "Rotativa", "-q", result );
    
    File.WriteAllBytes( outputPath, pdfByteArray );
