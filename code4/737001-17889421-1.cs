    // list of extensions you want removed
    String[] badExtensions = new[]{ ".asm" };
    // original filename
    String filename = "test.asm";
    // test if the filename has a bad extension
    if (badExtensions.Contains(Path.GetExtension(filename).ToLower())){
        // it does, so remove it
        filename = Path.GetFileNameWithoutExtension(filename);
    }
