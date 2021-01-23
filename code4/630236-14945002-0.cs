    string pathToImage = "/media/pictures/image1.jpg";
    
    string dirName = System.IO.Path.GetDirectoryName(pathToImage);
    string fileName = System.IO.Path.GetFileName(pathToImage);
    string thumbImage = System.IO.Path.Combine(dirName, "thumb", fileName);
    
    Debug.WriteLine("dirName: " + dirName);
    Debug.WriteLine("fileName: " + fileName);
    Debug.WriteLine("thumbImage: " + thumbImage);
