    using (FileStream sourceFile = System.IO.File.Open(localFilePath, FileMode.Open, FileAccess.Read))
    {
        ctx.AddObject(libraryName, document);
        ctx.SetSaveStream(document, sourceFile, true, mimeType, fullLibraryPath + "/" + document.Name);
        try
        {
            ctx.SaveChanges();
        }
        catch (Exception)
        {
            _ctx.DeleteObject(document);
            _ctx.SaveChanges();
            // TODO: log the exception
        }
    }
