    Microsoft.Win32.OpenFileDialog d = new Microsoft.Win32.OpenFileDialog();
    d.FileName = "Document";//begin map 
    d.DefaultExt = ".pdf";
    d.Filter = "PDF Files(*.pdf)|*.pdf";
    Nullable<bool> pad = d.ShowDialog();
    pdfPad = d.FileName;
    File.Delete(AppDomain.CurrentDomain.BaseDirectory+"1.jpg");
    pdfconverter.convertPDF(1, pdfPad);
    pdfAantalPaginas = pdfconverter.getAantalPaginas(pdfPad);
    Uri test = new Uri(AppDomain.CurrentDomain.BaseDirectory + "1.jpg");
    PaginaHolder.Source = BitmapFromUri(test);
    PaginaHolder.Source.Freeze();
