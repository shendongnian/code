    //b1 
    for (int i = 0; i < filepaths.Count; i++)
    {
        StorageFile f = await data.GetFileAsync(filepaths[i]);
        using (var stream = await f.OpenStreamForReadAsync())
        {
            using (StreamReader r = new StreamReader(stream))
            {
                filecontent = await r.ReadToEndAsync();
            }
        }
    }
    //b5
    for (int i = 0; i < filepaths.Count; i++)
    {
        StorageFile f = await data.GetFileAsync(filepaths[i]);
        using (var stream = await f.OpenStreamForReadAsync())
        {
            using (StreamReader r = new StreamReader(stream))
            {
                filecontent = r.ReadToEnd();
            }
        }
    }
