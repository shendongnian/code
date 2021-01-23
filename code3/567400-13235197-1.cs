    ...
    var mem = new MemoryStream();
    using (var stream = reponse2.GetResponseStream())
    {
            stream.CopyTo(mem);
    }
    mem.Seek(0L, SeekOrigin.Begin);
    ...
    fileService.WriteFile(currentFileName, mem.ToArray());
