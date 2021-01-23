    <!-- language: lang-cs -->
    // Get the image from the spreadsheet
    SpreadsheetGear.Shapes.IShape chart7 = worksheet.Shapes["Chart 7"];
    SpreadsheetGear.Drawing.Image image7 = new SpreadsheetGear.Drawing.Image(chart7);
    saveChartImage(image7, "Chart7.png");
    
    //Save chart images to the server
    private void saveChartImage(SpreadsheetGear.Drawing.Image image, string chartName)
    {
        var imageFile = System.IO.Path.Combine(imagePath, chartName);
        System.Drawing.Image bitmap = image.GetBitmap();
        bitmap.Save(imageFile, System.Drawing.Imaging.ImageFormat.Png);
    }
    
    // Action result to get image    
    public ActionResult getImage(string imageDir, string filename)
    {
        var file = filename;
        var fullPath = Path.Combine(imageDir, file);
        return File(fullPath, "image/png", file);
    }
