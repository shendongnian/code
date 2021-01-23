    // not sure about the type of obj
    public async Task<Image> LoadImage(string fileName, dynamic obj)
    {
        var file = await folder.GetFileAsync(fileName);
        using (var stream = await file.OpenAsync(FileAccessMode.Read))
        {
            obj.Image = new BitmapImage();
            await obj.Image.SetSourceAsync(stream);
        }
    }
    var tasks = fileNames.Select(f => LoadImage(f, obj)).ToArray();
    await Task.WhenAll(tasks);
