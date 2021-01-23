    foreach (Images item in ListOfImages)
    {
        newPath = Path.Combine(newPath, item.ImageName + item.ImageExtension);
        File.WriteAllBytes(newPath, item.File);
    }
