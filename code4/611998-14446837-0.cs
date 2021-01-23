    var file1 = File.ReadAllLines(path1);
    var file2 = File.ReadAllLines(path2);
    var onlyInFileA = file1.Except(file2);
    var onlyInFileB = file2.Except(file1);
    foreach(string line in onlyInFileA)
    {
        // ...
    }
    foreach(string line in onlyInFileB)
    {
        // ...
    }
