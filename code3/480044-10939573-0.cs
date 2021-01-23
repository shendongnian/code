    var file1Lines = System.IO.File.ReadAllLines(file1Path);
    var file2Lines = System.IO.File.ReadAllLines(file2Path);
    var totalCount = file1Lines.Length -1 + file2Lines.Length -1;
    var file3FirstLine = new[] { totalCount.ToString() };
    var file3Lines = file3FirstLine.Concat(file1Lines.Skip(1))
                                   .Concat(file2Lines.Skip(1));
    System.IO.File.WriteAllLines(file3Path, file3Lines);
