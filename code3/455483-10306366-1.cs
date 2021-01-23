    void Document_BeginPrint(object sender, PrintEventArgs e) {
      labelsPrinted = 0;
      float fPerPage = LabelsHorizontal * LabelsVertical;
      if (1 < fPerPage) {
        float fQty = labelsRequested;
        float fTotal = fQty / fPerPage;
        PrintPreview.Document.PrinterSettings.Copies = (short)fTotal;
      }
    }
    void Document_EndPrint(object sender, PrintEventArgs e) {
      Printed = (labelsPrinted == labelsRequested);
    }
