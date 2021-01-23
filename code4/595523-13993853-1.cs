    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        Parallel.ForEach(Directory.EnumerateFiles(_folder, _filter, SearchOption.AllDirectories), Search);
    }
    //_array contains the binary pattern I am searching for.
    private void Search(string filePath)
    {
        if (Contains(filePath, _array))
        {
            //filePath points at a match.
        }
    }
    private static bool Contains(string path, byte[] search)
    {
        //I am doing ReadAllBytes due to the fact that I am doing a binary search not a text search
        //  There are no "Lines" to seperate out on.
        var file = File.ReadAllBytes(path);
        var result = Parallel.For(0, file.Length - search.Length, (i, loopState) =>
            {
                if (file[i] == search[0])
                {
                    byte[] localCache = new byte[search.Length];
                    Array.Copy(file, i, localCache, 0, search.Length);
                    if (Enumerable.SequenceEqual(localCache, search))
                        loopState.Stop();
                }
            });
        return result.IsCompleted == false;
    }
