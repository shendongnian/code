    ...
    using (var reader = new BinaryReader(reponse2.GetResponseStream()))
    {
        bytes = new byte[reponse2.ContentLength];
        reader.Read(bytes, 0, (int)reponse2.ContentLength);
    }
    ...
    fileService.WriteFile(currentFileName, bytes);
