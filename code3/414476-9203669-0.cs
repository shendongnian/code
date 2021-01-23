    WIA.CommonDialog dialog = new WIA.CommonDialog();
    WIA.Device camera = dialog.ShowSelectDevice(WIA.WiaDeviceType.CameraDeviceType, false, true);
    WIA.Item takenItem = camera.ExecuteCommand("{AF933CAC-ACAD-11D2-A093-00C04F72DC3C}");
    
    foreach (string formatId in takenItem.Formats)
    {
        if (Guid.Parse(formatId) == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
        {
            WIA.ImageFile wiaImage = takenItem.Transfer(formatId);
    
            var imageData = new MemoryStream( wiaImage.FileData.get_BinaryData());
            var image = Image.FromStream(imageData);
            //pictureBox1.Image = image;
        }
    }
