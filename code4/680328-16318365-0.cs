    newImage.EnhanceImage();
    var tmpname = tempFileNamePath + ".bak";
    System.IO.File.Delete(tmpname);
    System.IO.File.Move(tempFileNamePath, tmpname);
    try {
        newImage.Save(tempFileNamePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
    catch {
        System.IO.File.Move(tmpname, tempFileNamePath);
        throw;
    }
    finally {
        newImage.Dispose();
    }
    System.IO.File.Delete(tmpname);
