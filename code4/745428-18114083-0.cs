    foreach (var file in System.IO.Directory
                             .GetFiles(System.IO.Path.Combine(root, "Images")))
    {
        // This will give you the relative URL of each file.
        var fileUrl = ResolveUrl(file.Replace(root, string.Empty).Replace("\\", "/"));
    }
