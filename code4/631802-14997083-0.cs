    using (FilterReader filterReader = new FilterReader(path, Path.GetExtension(path)))
    {
         filterReader.Init();
         string content = filterReader.ReadToEnd();
    }
