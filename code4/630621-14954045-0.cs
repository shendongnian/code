    string _sSuggestedName = String.Empty;
    byte[] byteViewerPDF = _reportViewer.LocalReport.Render("PDF");  
    byte[] byteViewerExcel = _reportViewer.LocalReport.Render("Excel");  
    byte[] byteViewerWord = _reportViewer.LocalReport.Render("Word");
    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
    saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf| Doc files
    (*.doc)|*.doc| Excel files (*.xls)|*.xls";
    if (saveFileDialog1.ShowDialog() == DialogResult.Ok)
    {
      FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
      if (saveFileDialog1.FilterIndex == 1)
      {
        newFile.Write(byteViewerPDF, 0, byteViewerPDF.Length);
        newFile.Close();
      }
      else
        if (saveFileDialog1.FilterIndex == 2)
        {
          newFile.Write(byteViewerWord, 0, byteViewerWord.Length);
          newFile.Close();
        }
      else
        if (saveFileDialog1.FilterIndex == 3)
        {
          newFile.Write(byteViewerExcel, 0, byteViewerExcel.Length);
          newFile.Close();
        }
    }
