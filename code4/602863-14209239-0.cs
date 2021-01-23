    var dlg = new FileOpenPicker();
    dlg.FileTypeFilter.Add(".png");
    var file = await dlg.PickSingleFileAsync();
    if (file != null)
    {
        currentBarcode = new WriteableBitmap(89, 89);
        using (var stream = await file.OpenReadAsync())
        {
            currentBarcode.SetSource(stream);
        }
        imgDecoderBarcode.Source = currentBarcode;
        var result = reader.Decode(currentBarcode);
        if (result != null)
        {
            txtDecoderType.Text = result.BarcodeFormat.ToString();
            txtDecoderContent.Text = result.Text;
        }
        else
        {
            txtDecoderType.Text = String.Empty;
            txtDecoderContent.Text = "No barcode found.";
        }
    }
