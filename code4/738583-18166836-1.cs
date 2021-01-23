    //b10
    for (int i = 0; i < filepaths.Count; i++)
    {
        using (var stream = new IsolatedStorageFileStream("/benchmarks/samplefiles/" + filepaths[i], FileMode.Open, store))
        {
            using (StreamReader r = new StreamReader(stream))
            {
                filecontent = await Task.Factory.StartNew<String>(() => { return r.ReadToEnd(); });
            }
        }
    }
    //b19
    await await Task.Factory.StartNew(async () =>
    {
        for (int i = 0; i < filepaths.Count; i++)
        {
            using (var stream = new IsolatedStorageFileStream("/benchmarks/samplefiles/" + filepaths[i], FileMode.Open, store))
            {
                using (StreamReader r = new StreamReader(stream))
                {
                    filecontent = await Task.Factory.StartNew<String>(() => { return r.ReadToEnd(); });
                }
            }
        }
    });
