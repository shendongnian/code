    public int Print(string docName, int rows, int columns, int copies) {
      LabelsHorizontal = rows;
      LabelsVertical = columns;
      if (!String.IsNullOrEmpty(docName)) {
        PrintPreview.Document.DocumentName = docName;
      }
      labelsRequested = copies;
      //PrintPreview.Document.PrinterSettings.Copies = (short)copies;
      PrintPreview.SettingsFilename = Settings.PageSettingsLocation;
      if (!PrintPreview.PrinterSelected) {
        if (PrintPreview.ShowPrinterSelectDialog() != DialogResult.OK) {
          return 0;
        }
      }
      if (ShowPrintPreview) {
        Size docSize = PrintPreview.Document.DefaultPageSettings.Bounds.Size;
        float height = 0.8F * Screen.PrimaryScreen.WorkingArea.Size.Height;
        float width = (height * docSize.Width) / docSize.Height;
        Size winSize = new Size((int)width, (int)height);
        PrintPreview.Height = winSize.Height;
        PrintPreview.Width = winSize.Width;
        PrintPreview.Document.PrinterSettings.Copies = (short)labelsRequested; // this may cause problems
        PrintPreview.ShowDialog();
      } else {
        PrintPreview.PrintDocument();
      }
      return labelsPrinted;
    }
