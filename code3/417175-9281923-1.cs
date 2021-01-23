    PdfPTable table = new PdfPTable(1);
    table.WidthPercentage = 100;
    foreach (string path in imagePaths) {
      Image image = Image.GetInstance(path);
      PdfPCell cell = new PdfPCell(image, true);
      cell.Border = Rectangle.NO_BORDER;
      table.AddCell(cell);
    }
    document.Add(table);
