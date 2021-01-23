    string extension = "";
    switch (format)
    {
     case (System.Drawing.Imaging.ImageFormat.Jpeg);
        extension = ".jpg"; break;
        .
        .
        .
    }
    bitMap.Save("testImage"+extension, System.Drawing.Imaging.ImageFormat.Jpeg);
